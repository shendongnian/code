    var factories = new Factory[] { Factory1, Factory2, Factory3, Factory4 }
        .OrderBy(x => x.getRemaining()) // or, you can use OrderByDescending 
        .ToArray();
    
    remaining1 = factories[0].getRemaining();
    remaining2 = factories[1].getRemaining();
    remaining3 = factories[2].getRemaining();
    remaining4 = factories[3].getRemaining();
