    //suppose your attributes is a set of Attribute
    var p = Expression.Parameter(typeof(Attribute));
    var p1 = Expression.Property(p, "Prop1ID");
    var p2 = Expression.Property(p, "Prop2ID");
    var initBool = Expression.Constant(false) as Expression;
    //build the BodyExpression for the predicate
    var body = L1.Aggregate(initBool, (c,e) => {
                   var ep1 = Expression.Constant(e.Prop1);
                   var ep2 = Expression.Constant(e.Prop2);
                   var and = Expression.And(Expression.Equal(ep1, p1), Expression.Equal(ep2,p2));
                   return Expression.Or(c, and); 
               });
    attributes.Where(Expression.Lambda<Func<Attribute, bool>>(body, p));
