    var open = new Queue<Point>();
    // ... Fill it
    // Any() is in general faster than Count() for checking that collection has data
    // It is a good practice to use it in general, although Count (the property) is as fast
    // but not all enumerables has that one
    while (open.Any())     {
       Point p = open.Dequeue();
       // ... Do stuff
    }
