    //..other code
    string[] split = sentenceTwo.Split(new char[]{' ', '.', ','}, System.StringSplitOptions.RemoveEmptyEntries);
    foreach (string item in split)
    {
        Console.WriteLine(item);
    }
    //..other code
