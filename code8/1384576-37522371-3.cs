    var conv = new DocConverter();
    conv.Register<Beer, BeerSource>( 
        "beer", 
        ( o ) => new BeerSource { Name = o.Name, Brewery = o.Brewery, Address = o.Address, }, 
        ( id, o ) => new Beer { Id = id, Name = o.Name, Brewery = o.Brewery, Address = o.Address, } );
    conv.Register<Brewery, BrewerySource>( 
        "brewery", 
        ( o ) => new BrewerySource { Name = o.Name, Date = o.Date, City = o.City, }, 
        ( id, o ) => new Brewery { Id = id, Name = o.Name, Date = o.Date, City = o.City, } );
