    foreach(var g in groupedExample){
        Console.WriteLine(String.Format("Day {0} at hour {1} with id {2}", g.Key.Date, g.Key.Hour, g.Key.Id));
    
        foreach(var example in g)
            Console.WriteLine(" - " + example.Name);
    }
