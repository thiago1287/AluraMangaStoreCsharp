//hanabi comics 花火 ℌ𝔞𝔫𝔞𝔟𝔦
string mensagemDeBoasVindas = "Boas Vindas a Hanabi Comics!";

Dictionary<string, List<int>> mangasRegistrados = new Dictionary<string, List<int>>();
mangasRegistrados.Add("ORV", new List<int> { 10, 10, 10 });
mangasRegistrados.Add("Solo", new List<int>());
mangasRegistrados.Add("One Piece", new List<int> { 9, 10, 9, 10, 10, 10});


void ExibirLogo()
{
    Console.WriteLine(@"

░░██╗      ██╗░░██╗░█████╗░███╗░░██╗░█████╗░██████╗░██╗      ██╗░░
░██╔╝      ██║░░██║██╔══██╗████╗░██║██╔══██╗██╔══██╗██║      ╚██╗░
██╔╝░      ███████║███████║██╔██╗██║███████║██████╦╝██║      ░╚██╗
╚██╗░      ██╔══██║██╔══██║██║╚████║██╔══██║██╔══██╗██║      ░██╔╝
░╚██╗      ██║░░██║██║░░██║██║░╚███║██║░░██║██████╦╝██║      ██╔╝░
░░╚═╝      ╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝╚═════╝░╚═╝      ╚═╝░░

" );
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um mangá");
    Console.WriteLine("Digite 2 para mostrar todos os mangás");
    Console.WriteLine("Digite 3 para avaliar um mangá");
    Console.WriteLine("Digite 4 para exibir a média de um mangá");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNum)
    {
        case 1: RegistrarMangas();
            break;
        case 2:
            MostrarTodosMangas();
            break;
        case 3:
            AvaliarMangas();
            break;
        case 4:
            CalcularMedia();
            break;
        case 0:
            Console.WriteLine("SAYONARA :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarMangas()
{
    Console.Clear();
    ExibirSubtitulos("REGISTRO DOS MANGÁS");
    Console.Write("Digite o nome do Mangá: ");
    string nomeDoManga = Console.ReadLine()!;
    Console.WriteLine($"O mangá {nomeDoManga} foi registrado com sucesso!");
    mangasRegistrados.Add(nomeDoManga, new List<int>());
    Thread.Sleep(700);
    Console.Clear() ;
    ExibirMenu();
}

void MostrarTodosMangas()
{
    Console.Clear();
    ExibirSubtitulos("TODOS OS MANGÁS REGISTRADOS");
    int i = 1; 
    foreach (string manga in mangasRegistrados.Keys)
    {
        Console.WriteLine($"Mangá {i}: {manga}");
        i++;
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void ExibirSubtitulos(string titulo)
{
    int qntDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qntDeLetras + 32, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine("\t\t" + titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarMangas()
{
    //receber qual manga
    //se existir no dicionario atribuir nota
    //senao retornar erro

    Console.Clear();
    ExibirSubtitulos("AVALIAR MANGÁS");
    Console.Write("Digite o nome do mangá que você quer avaliar: ");
    string nomeDoManga = Console.ReadLine()!;
    if (mangasRegistrados.ContainsKey(nomeDoManga)) 
    {
        Console.Write($"Qual nota o mangá {nomeDoManga} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        mangasRegistrados[nomeDoManga].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi dada ao mangá {nomeDoManga}!");
        Console.WriteLine("\n\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"{nomeDoManga} não foi encontrado");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void CalcularMedia()
{
    Console.Clear();
    ExibirSubtitulos("VER MEDIA DOS MANGÁS");
    Console.Write("Digite o nome do mangá que você quer ver a média das avaliações: ");
    string nomeDoManga = Console.ReadLine()!;
    if (mangasRegistrados.ContainsKey(nomeDoManga))
    {
        List<int> notasDosMangas = mangasRegistrados[nomeDoManga];       
        Console.Write($"\nO mangá {nomeDoManga} tem a média de: {notasDosMangas.Average()}.");
        Console.WriteLine("\n\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"{nomeDoManga} não foi encontrado");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

ExibirMenu();
