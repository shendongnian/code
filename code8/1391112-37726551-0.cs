    var lines = new[]
    {
        @"Case 1: Bug A is resolved (ID: X015)",
        "Case 2: Bug B is resolved (ID: X016)",
        "Case 3: Bug C is resolved (Data issue) (ID: X017)"
    };
    
    foreach(var line in lines)
    {
    
        Regex regex = new Regex(@"(?<=[(]ID:\s)X\d*(?=[)])");
    
        Match match = regex.Match(line);
    
        if(match.Success)
        {
            Console.WriteLine(match.Value);
        }
    }
    
    Console.ReadLine();
