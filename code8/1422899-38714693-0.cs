    var moves = Enumerable.Range(0, 5).Select(x => {
        Console.WriteLine("Generating");
        return x;
    });
    
    var aggregate = moves.Aggregate((p, c) => {
        Console.WriteLine("Aggregating");
        return p + c;
    });
    
    var newMoves = moves.Where(x => {
        Console.WriteLine("Filtering");
        return x % 2 == 0;
    });
    
    newMoves.ToList();
