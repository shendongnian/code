    var list = new List<ICacheable>();
    list.Add(new MyEntity());
    var something = new MyEntity();
    // works 
    list[0].CloneTo(something);
