    static void Main()
    {
        var myString = "Hey there" + Environment.NewLine + "How are you doing?";
        foreach (var character in myString)
        {
            Console.Write(character);
            Thread.Sleep(30);
        }
        Console.WriteLine();
        Console.ReadLine();
    }
