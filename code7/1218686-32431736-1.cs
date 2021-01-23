    var items = new List<Expression<Func<SomeModel, object>>>
                {
                    x => x.Property1,
                    x => x.Property1.P1ChildProperty1,
                    x => x.Property1.P1ChildProperty2,
                    x => x.Property2,
                    x => x.Property2.P2ChildProperty1,
                    x => x.Property2.P2ChildProperty2,
                    x => x.Property2.P2ChildProperty3
                };
    Func<LambdaExpression, Expression<Func<object, object>>> reBase = 
                x =>
                {
                    var memExpr = (MemberExpression)x.Body;
                    var param = Expression.Parameter(typeof(object), "x");
                    var typedParam = Expression.Convert(param, memExpr.Member.DeclaringType);
                    var property = Expression.Property(typedParam, memExpr.Member.Name);
                    return Expression.Lambda<Func<object, object>>(property, param);
                };
    var groupedItems = (from item in items
                        group item by ((MemberExpression)item.Body).Member.DeclaringType into g
                        select g.Select(x => reBase(x)).ToList()).ToList();
