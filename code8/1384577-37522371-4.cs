    object source;
    object result;
    string jsonData;
    source = new Beer { Id = 123, Name = "myBeer", Brewery = "myBrewery", Address = "blah", };
    jsonData = conv.Serialize( source );
    // check the JSON result
    Console.WriteLine( jsonData );
    result = conv.Deserialize( jsonData );
    // check the result type
    Console.WriteLine( result.GetType().ToString() );
    source = new Brewery { Id = 456, Name = "myBrewery", Date = "somedate", City = "somecity", };
    jsonData = conv.Serialize( source );
    // check the JSON result
    Console.WriteLine( jsonData );
    result = conv.Deserialize( jsonData );
    // check the result type
    Console.WriteLine( result.GetType().ToString() );
