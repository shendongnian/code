    class MyClass
    {
       string Name {get; set;}
    }
    
    var listString = new List<MyClass>() {/* Fill in with Data */};
    var match = listString.FirstOrDefault(x => x.Name == "VesselId");
    
    if(!string.IsNullOrEmpty(match))
         listString.Remove(match);
