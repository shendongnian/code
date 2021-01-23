    string propName = "Age";
    var paramExpression = Expression.Parameter(typeof(Obj1));
    // o =>
    var memberExpression = Expression.Property(paramExpression, propName);
    // o => o.Age
    var lambdaExpression = Expression.Lambda<Func<Obj1, string>>(memberExpression, paramExpression);
    // (o => o.Age)
    var compiled = lambdaExpression.Compile();
            
    IList<Obj1> objTemp = new List<Obj1>();
    for (var i = 0; i < 15; i++) {
        Obj1 temp = new Obj1();
        temp.Name = "Name" + i;
        temp.Age = "Age" + i;
        temp.Company = "Company" + i;
        objTemp.Add(temp);
    }
    var results = objTemp.Select(compiled);
    // equivalent to objTemp.Select(o => o.Age), plus a delegate call and the time to 
    // compile the lambda. 
