    var pers = Expression.Parameter(typeof(Person), "x");    
    var propName = Expression.Property(pers, "Name");
    var nameAsConstant = Expression.Constant(person.Name);               
    var equal = Expression.Equal(propName, nameAsConstant);      
    var propAge = Expression.Property(pers, "Age");  
    var ageConstant = Expression.Constant(20);
    var greater = Expression.GreaterThan(propAge, ageConstant);
    var conditions = Expression.AndAlso(equal, greater);
    var lambda = Expression.Lambda<Func<Person, bool>>(conditions, pers);
    var lambdaStr = lambda.ToString(); //x => ((x.Name == "John") AndAlso (x.Age > 20))
