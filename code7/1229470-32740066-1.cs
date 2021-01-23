    var pers = Expression.Parameter(typeof(Person), "x"); //The parameter to the expression(its type and its name)
    var propName = Expression.Property(pers, "Name"); // The property "Name" of the parameter(x.Name)
    var nameAsConstant = Expression.Constant(person.Name); // The value I will compare to x.Name
    var equal = Expression.Equal(propName, nameAsConstant); // The comparison(x.Name == "John")
    var propAge = Expression.Property(pers, "Age"); // The property "Age" of the parameter(x.Age)
    var ageConstant = Expression.Constant(20); // The value I will compare to x.Age
    var greater = Expression.GreaterThan(propAge, ageConstant); // The comparison(x.Age > 20)
    var conditions = Expression.AndAlso(equal, greater); // Merging the expression with && [(x.Name == "John") AndAlso (x.Age > 20)]
    var lambda = Expression.Lambda<Func<Person, bool>>(conditions, pers); // Build the expression
    var lambdaStr = lambda.ToString(); //x => ((x.Name == "John") AndAlso (x.Age > 20))
