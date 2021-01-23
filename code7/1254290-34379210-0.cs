    public static IQueryable<IGrouping<object, TSource>> DynamicGroupBy<TSource>
           (this IQueryable<TSource> query, params string[] properties)
    {
        var entityType = typeof(TSource);
        var props = properties.Select(x => entityType.GetProperty(x)).ToList();
        var source = Expression.Parameter(entityType, "x");
        // create x=> new myType{ prop1 = x.prop1,...}
        var newType = CreateNewType(props);
        var binding = props.Select(p => Expression.Bind(newType.GetField(p.Name), 
                      Expression.Property(source, p.Name))).ToList();
        var body = Expression.MemberInit(Expression.New(newType), binding);
        var selector = Expression.Lambda(body, source);
        //Get System.Linq.Queryable.GroupBy() method.
        var queryable = typeof(System.Linq.Queryable);
        var method = queryable.GetMethods()
             .Where(m => m.Name == "GroupBy" && m.IsGenericMethodDefinition)
             .Where(m =>
             {
                var parameters = m.GetParameters().ToList();
                return parameters.Count == 2;
             }).Single();
        MethodInfo genericMethod = method.MakeGenericMethod(entityType, newType);
       //Call query.GroupBy(selector)
       var newQuery = (IQueryable<IGrouping<object, TSource>>)genericMethod
                 .Invoke(genericMethod, new object[] { query, selector });
       return newQuery;
    }
    public static Type CreateNewType(List<PropertyInfo> props)
    {
       AssemblyName asmName = new AssemblyName("MyAsm");
       AssemblyBuilder dynamicAssembly = AssemblyBuilder
           .DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
       ModuleBuilder dynamicModule = dynamicAssembly.DefineDynamicModule("MyAsm");
       TypeBuilder dynamicAnonymousType = dynamicModule
           .DefineType("MyType", TypeAttributes.Public);
       foreach (var p in props)
       {
           dynamicAnonymousType.DefineField(p.Name, p.PropertyType, FieldAttributes.Public);
       }
       return dynamicAnonymousType.CreateType();
    }
