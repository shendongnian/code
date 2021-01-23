    using inercya.EntityLite;
    using inercya.EntityLite.Extensions;
    
    //......
    
    MyEntity SomeMethod()
    {
        using (reader = GetDataReaderFromQuery())
        {
    
             return reader.FirstOrDefault<MyEntity>();
        }
    }
