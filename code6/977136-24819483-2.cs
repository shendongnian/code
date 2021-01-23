    string[] strArr = new string[] { "2.4 kWh @ 105.00 c/kWh", "Hello, world" };
    var newArr = strArr.Select(s => s.Split(' ').ToArray()).ToArray();
    for (int i = 0; i < newArr.Length; i++)
    {
        for(int j = 0; j < newArr[i].Length; j++)
            Console.WriteLine(newArr[i][j]);
        Console.WriteLine();
    }
    //  2.4
    //  c/kWh
    //  @
    //  105.00
    //  kWh
    //
    //  Hello,
    //  world
