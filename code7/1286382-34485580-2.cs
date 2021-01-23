    var text = System.IO.File.ReadAllText("file.txt");
    var dictionary = new Dictionary<char,int>();
    //count every letter
    foreach (var symbol in text)
    {
        //skip non letter characters
        if (!char.IsLetter(symbol))
             continue;
    
        var key = char.ToLower(symbol);
        if (dictionary.ContainsKey(key))
             dictionary[key]++;
        else
             dictionary.Add(key,1);
    }
    //result output
    foreach (var pair in dictionary.OrderBy(p => p.Key))
    {
        Console.Write("{0}: {1} ", pair.Key, pair.Value);
    }
