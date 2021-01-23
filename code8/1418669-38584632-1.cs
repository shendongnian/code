    var items = new List<MatchItem>()
    {
        new MatchItem{SomeInt = 1, SomeDecimal = 0.3M},
        new MatchItem{SomeInt = 12, SomeDecimal = 2.3M}
    };
    
    var searchItem = new MatchItem{SomeInt = 1, SomeDecimal = 0.3M};
    
    Console.WriteLine(items.Contains(searchItem)); // true
