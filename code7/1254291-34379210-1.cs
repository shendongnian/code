    public static Expression<Func<TSource, object>> DynamicGroupBy<TSource>
           (params string[] properties)
    {
        var entityType = typeof(TSource);
        var props = properties.Select(x => entityType.GetProperty(x)).ToList();
        var source = Expression.Parameter(entityType, "x");
        // create x=> new myType{ prop1 = x.prop1,...}
        var newType = CreateNewType(props);
        var binding = props.Select(p => Expression.Bind(newType.GetField(p.Name), 
                      Expression.Property(source, p.Name))).ToList();
        var body = Expression.MemberInit(Expression.New(newType), binding);
        var selector = Expression.Lambda<Func<TSource, object>>(body, source);
       return selector;
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
