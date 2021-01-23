    //Should return "Length", value type property
    StaticReflection.GetMemberName<string>(x => x.Length);
    
    //Should return "Data", reference type property
    StaticReflection.GetMemberName<Exception>(x => x.Data);
    
    //Should return "Clone", method returning reference type
    StaticReflection.GetMemberName<string>(x => x.Clone());
    
    //Should return "GetHashCode", method returning value type
    StaticReflection.GetMemberName<string>(x => x.GetHashCode());
    
    //Should return "Reverse", void method
    StaticReflection.GetMemberName<List<string>>(x => x.Reverse());
    
    //Should return "LastIndexOf", method with parameter
    StaticReflection.GetMemberName<string>(x => x.LastIndexOf(','));
