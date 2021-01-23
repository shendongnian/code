    string[] lines = File.ReadAllLines(@"E:Sum.txt");
    string str = string.Empty;
    foreach (string line in lines)
    {
        if (line.Contains("x"))
        {
            str += line;                   
            Console.WriteLine();
            continue;
        }
        break;
    }
    Console.WriteLine("Press any key to exit.");
    System.Console.ReadKey();
