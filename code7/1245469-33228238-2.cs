    class Car
    {
    public Engine Engine{get;set;}
    
    // Since car has more than one tyres, it should be one to many relation
    public List<Tyre> Tyres{get;set;}
    
    }
