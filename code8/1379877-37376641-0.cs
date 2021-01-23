    var p = Expression.Parameter(typeof(AnalysisResponseMeasure), "p");
    var prediacte = Expression.Lambda<Func<AnalysisResponseMeasure, bool>>(Expression.Equal(Expression.Property(p, "MeasureTypeId"), Expression.Constant(1)), p);
    var firstMethod = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                        .Single(m => m.Name == "First" &&
                                                     m.GetParameters().Length == 2 &&
                                                     m.GetParameters()[1].ParameterType.IsGenericType &&
                                                     m.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Func<,>))
                                        .MakeGenericMethod(typeof(AnalysisResponseMeasure));
    var foo = Expression.Parameter(typeof(Foo), "foo");
    var first = Expression.Call(firstMethod, Expression.Property(foo, "AnalysisResponseMeasures"), prediacte);
    var measureValue = Expression.Property(first, "MeasureValue");
    var yourExpression = Expression.Lambda<Func<Foo, double>>(measureValue, foo);
