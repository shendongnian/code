    public void Register(TypeMap typeMap, ITypeMapCollection dependencies = null) {
        container.Configure(x => {
            var use = x.For(typeMap.ServiceType)
                       .Use(typeMap.ConcreteType);
            if (typeMap.Name.IsNotNullOrEmpty()) {
                use.Named(typeMap.Name);
            }
            if (dependencies.IsNotNullOrEmpty()) {
                x.For(typeMap.ServiceType).Use("composite", BuildExpression(typeMap, dependencies));
            }
        });
    }
    private Func<IContext, object> BuildExpression(TypeMap typeMap, ITypeMapCollection dependencies) {
        var contextParameter = Expression.Parameter(typeof(IContext), "context");
        var @params = dependencies.ToArray(d => d.ServiceType);
        var ctorInfo = typeMap.ConcreteType.GetConstructor(@params);
        var genericMethodInfo = typeof(IContext).GetMethods().First(method => {
            return method.Name.Equals("GetInstance") &&
                    method.IsGenericMethodDefinition &&
                    method.GetParameters().Length == 1;
        });
        var getInstanceCallExpressions = dependencies.Select(dependency => {
            var nameParam = Expression.Constant(dependency.Name, typeof(string));
            var methodInfo = genericMethodInfo.MakeGenericMethod(new[] { dependency.ServiceType });
            return Expression.Call(contextParameter, methodInfo, new[] { nameParam });
        });
        var lambda = Expression.Lambda<Func<IContext, object>>(
                        Expression.New(ctorInfo, getInstanceCallExpressions),
                        contextParameter);
        return lambda.Compile();
    }
