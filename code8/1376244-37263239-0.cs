    IReadOnlyDictionary<Foo, Bar> baz = GetDictionary();
    
    IEnumerable<Foo> keys = baz.Keys;
    IReadOnlyCollection<Foo> keysCollection = keys as IReadOnlyCollection<Foo>;
    
    if(keysCollection != null)
    {
        //This code will execute for the built in implmentation of `ReadOnlyDictionary<Foo, Bar>`
    }
