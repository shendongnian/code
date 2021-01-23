    IRazorLightEngine engine = EngineFactory.CreatePhysical("Path-to-your-views");
    
    // Files and strong models
    string resultFromFile = engine.Parse("Test.cshtml", new Model("SomeData")); 
    
    // Strings and anonymous models
    string stringResult = engine.ParseString("Hello @Model.Name", new { Name = "John" }); 
