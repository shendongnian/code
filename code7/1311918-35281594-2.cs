    string string1 = "ghuitghtruighr";
    for (int index = 0; index < string1.Length; index += 5)
    {
        string subString = string1.Substring(index);
        if(subString.Length > 5)
            subString = subString.Substring(0, 5);
        Console.WriteLine(subString);
    }
