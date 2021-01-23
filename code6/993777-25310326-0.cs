    var ctx = new MyContext();
    ctx.Configuration.ProxyCreationEnabled = true;
    
    dynamic dynamicEntity = ctx.Employees.First();
    var entityWrapper = dynamicEntity._entityWrapper;
    
    Type type = entityWrapper.GetType();
    var contextProperty = type.GetProperty("Context");
    var objectContext = contextProperty.GetValue(entityWrapper) as ObjectContext;
