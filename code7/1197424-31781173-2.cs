    string test = "kelly tell stories";
    string[] split = test.Split(' '); //Use empty space between word(s) as split character
    for(int i=0; i< split.Length; i++)
    {
        Console.WriteLine(split[i]);
    }
    Console.ReadLine();
