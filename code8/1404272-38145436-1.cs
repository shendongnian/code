    var separator = 3;
    var collection = new [] { 1, 2, 3, 4, 5 };
    
    var i = Array.IndexOf(collection,separator);
    
    int[] part1 = new int[i];
    int[] part2 = new int[collection.Length - i];
    Array.Copy(collection, 0, part1, 0, i ); 
    Array.Copy(collection, i, part2, 0, collection.Length - i ); 
