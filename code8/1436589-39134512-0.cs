    var pList = new List<string>() 
    { 
        "01233[0-3]", "12356[1-3]", "55555[7-9]"
    };
    var paired = 
        pList.Select(x => 
            new KeyValuePair<int, string>
            (Int32.Parse(new String((new String(x.Where(Char.IsDigit).Reverse().ToArray()))
            .Substring(0, 4).Reverse().ToArray())), x));
            
    var pairedOrdered = paired.OrderByDescending(x => x.Key);
    foreach(var kvp in pairedOrdered)
    {
        Console.WriteLine("Key: {0} Value: {1}", kvp.Key, kvp.Value);
    }
