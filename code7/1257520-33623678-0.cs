    List<string> phrases = new List<string>() {"Cats and Dogs", "Cats and Bats", "Dogs and Trees"};
    IEnumerable<string> f = phrases.Where<string>(x =>x.Contains("Cats and Dogs"));
    System.Console.WriteLine(f.FirstOrDefault());
    > Cats and Dogs
    
