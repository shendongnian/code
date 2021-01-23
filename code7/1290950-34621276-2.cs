    [EnableQuery]
    public IQueryable<Base> GetFrom(ODataQueryOptions options)
    {
    	var typeName = options.Context.Path.Segments.OfType<CastPathSegment>().Single().CastTypeName;
    	var assemblyName = options.Context.ElementClrType.Assembly.GetName().Name;
    	var type = Type.GetType($"{typeName},{assemblyName}");
    
    	var ofType = typeof(Queryable).GetMethod("OfType").MakeGenericMethod(type);
   		return (IQueryable<Base>)ofType.Invoke(null, new object[] { this.Context.Bases });
    }
