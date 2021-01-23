    Console.InputEncoding = Encoding.Unicode;
    Console.OutputEncoding = Encoding.Unicode;
    string words;
    while ((words = Console.ReadLine()) != "quit")
    {
        Console.WriteLine(words);
    }
