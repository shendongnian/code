    public static bool IsNotSeparator(int value) => value != 3;
    var collection = new [] { 1, 2, 3, 4, 5 };
    
    var index = collection.TakeWhile(IsNotSeparator).Count();
    
    var part1 = new ArraySegment<int>( collection, 0, index );
    var part2 = new ArraySegment<int>( collection, index, collection.Length - index );
