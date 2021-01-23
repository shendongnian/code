	var provider = new DbContextProvider(() => GetScopedItem(CreateContext));
    container.RegisterSingleton<IDbContextProvider>(provider);
    static T GetScopedItem<T>(Func<T> valueFactory) where T : class {
        T val = (T)HttpContext.Current.Items[typeof(T).Name];
        if (val == null) HttpContext.Current.Items[typeof(T).Name] = val = valueFactory();
        return val;
    }    
	static DbContext CreateContext() {
		var header = HttpContext.Request.Headers.Get("custHeader");
		string connectionString = "conStr";//get con based on the header, from a remote DB here
		return new MyDynamicContext(connectionString);
	}		
