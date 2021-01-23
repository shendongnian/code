    for (int i = separatedStringList.Count - 1; i--; i > 0)
    {
        newString = String.Join("", separatedStringList.Take(i).ToArray());
        Console.WriteLine(newString);
    }
