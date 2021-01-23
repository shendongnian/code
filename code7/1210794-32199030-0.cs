    public Task<MyObject> FooAsync()
    {
        // do some stuff
        
        return GetSomeDataAsync();
    }
    public async Task<MyObject> GetSomeDataAsync()
    {
        using(var context = new myDBContext())
        {
            return await context.SomeDbSet.FirstOrDefault(o=>o.Something == true);  
        }
    }
