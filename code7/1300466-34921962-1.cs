    Console.WriteLine("Enter text: ");
    var text = Console.ReadLine();
    
    var skipping = false;
    
    var result = string.Empty;
    
    foreach (var c in text)
    {
        if (!skipping || c == '"') result += c;
        if (c == '"') skipping = !skipping;
    }
    
    Console.WriteLine(result);
    
    Console.ReadLine();
