    public List<DynamicContainer> IndexedProperties
    {
        get
        {
            return new List<DynamicContainer> 
            {
                new DynamicContainer(stringObject1),
                new DynamicContainer(stringObject2),
                new DynamicContainer(stringObject3),
                new DynamicContainer(dateTimeObject1),
                new DynamicContainer(dateTimeObject2),
                new DynamicContainer(stringObject4)
            };
        }
    }
    
    ...
    
     foreach(var prop in data.IndexedProperties)
        Console.WriteLine(prop.ValueMember.ToString());
   
