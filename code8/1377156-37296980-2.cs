    DbContext context = null;
    try 
    {
        context = new DbContext();
        ...stuff inside the using block ...
    }
    finally 
    {
        if(context!=null)
            context.Dispose()
    }
