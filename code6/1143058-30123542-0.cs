    var coll = new[] { "a", "A", "aA", "AA", "abc", "ABC", "AbC", "123", "hello World" };
    foreach (string str in coll)
    {
        int sum = str.Sum(c => (int)Char.ToUpper(c) - minLetter);
        Console.WriteLine(sum);
    }
