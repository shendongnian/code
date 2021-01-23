    var open = new Queue<Point>();
    // Fill it
    while (open.Any()) // Any is in general faster than count for enumeration, good practice to use it in general
    {
       Point p = open.Dequeue();
       // Do stuff
    }
