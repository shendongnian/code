    void MySyncMethodOnMyWindowServiceApp()
    {
       List<MyClass> myClasses = GetMyClassCollectionAsync().Result;
    }
    
    Task<List<MyClass>> GetMyListCollectionAsync()
    {
       var data = await GetDataAsync(); // <- long running call to remote WebApi?
       return data.ToObject<List<MyClass>>();
    }
