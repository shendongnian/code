    var conv = new DocConverter();
    conv.Register<Beer, BeerSource>( 
        "beer", 
        ( o ) => Tuple.Create( o.Id, new BeerSource { Name = o.Name, Brewery = o.Brewery, Address = o.Address, } ), 
        ( t ) => new Beer { Id = t.Item1, Name = t.Item2.Name, Brewery = t.Item2.Brewery, Address = t.Item2.Address, } );
    conv.Register<Brewery, BrewerySource>( 
        "brewery", 
        ( o ) => Tuple.Create( o.Id, new BrewerySource { Name = o.Name, Date = o.Date, City = o.City, } ), 
        ( t ) => new Brewery { Id = t.Item1, Name = t.Item2.Name, Date = t.Item2.Date, City = t.Item2.City, } );
