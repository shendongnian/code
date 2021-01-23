    using System.Linq.Expressions;
    using System.Reflection;
    var arg = Expression.Parameter(typeof(Person), "x");
    var property = Expression.Property(arg, "Name");
    //exp: x => x.Name
    var exp = Expression.Lambda<Func<Person, string>>(
                         property, new ParameterExpression[] { arg });
