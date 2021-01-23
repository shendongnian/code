    string[] test = new [] { "qwe 2", "a 2", "b 3", "asd 123" };
    
    foreach (var s in test)
    {
        var lastLetterIndex = Array.FindLastIndex(s.ToCharArray(), Char.IsLetter);
        var lastNumberIndex = Array.FindLastIndex(s.ToCharArray(), Char.IsNumber);
        Console.WriteLine(s);
        Console.WriteLine("Letter Length : " + (lastLetterIndex + 1));
        Console.WriteLine("Number Length : " + (lastNumberIndex - lastLetterIndex));
    }
    Console.ReadKey();
