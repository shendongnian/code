    String line = "qwerty/asdfg/xxx/zxcvb";
    
    string[] words = line.Split('/');
    int index = Array.IndexOf(words, "xxx");
    
    // Check to make sure you to go beyond the first element
    if (index - 1 > -1)
    {
        // Previous word
        Console.WriteLine(words[index - 1]);
    }
    
    // Check to make sure you to go beyond the last element    
    if (index != -1 && index + 1 < words.Length)
    {
        // Next word
        Console.WriteLine(words[index + 1]);
    }
    
    Console.ReadLine();
