    Dictionary<string, List<Example>> exampleDictionary = new Dictionary<string, List<Example>>();
    
    foreach(var x in exampleList)
    {
       if(!exampleDictionary.ContainsKey(x.Name)) {
          exampleDictionary[x.Name] = new List<Example>();
       } 
       exampleDictionary[x.Name].Add(x);       
    }
