    ParameterExpression target = Expression.Parameter(typeof(object), "target");
    ParameterExpression result = Expression.Parameter(typeof(object), "result");
    CallSiteBinder getName = Binder.GetMember(
       CSharpBinderFlags.None, "Name", typeof(Program),
       new CSharpArgumentInfo[] {
           CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
       }
    );
    CallSiteBinder getSurname= Binder.GetMember(
       CSharpBinderFlags.None, "Surname", typeof(Program),
       new CSharpArgumentInfo[] {
           CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
       }
    );
    BlockExpression block = Expression.Block(
        new[] { result },
        Expression.Assign(
            result,
            Expression.Call(typeof(string).GetMethod("Concat", new Type[] { typeof(object[]) }),
                            Expression.NewArrayInit(typeof(object),
                                 Expression.Dynamic(getName, typeof(object), target),
                                 Expression.Constant(" ", typeof(object)),
                                 Expression.Dynamic(getSurname, typeof(object), target)
                            )
           )
        )
    );
    Func<dynamic, object> myFunc = Expression.Lambda<Func<dynamic, object>>(block, target).Compile();
