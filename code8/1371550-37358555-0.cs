    IEnumerable<int> list = new List<int> { 3, 5, 7, 2, 12, 1 };
    var type = typeof(Enumerable); //This is the static class that contains Max
    //Find The overload of Max that matches the list
    var maxMethod = type.GetMethod("Max", new Type[] { typeof(IEnumerable<int>) });
    ParameterExpression p = Expression.Parameter(typeof(IEnumerable<int>));
    //Max is static, so the calling object is null
    var exp = Expression.Call(null, maxMethod, p); 
    var lambda = Expression.Lambda<Func<IEnumerable<int>, int>>(exp, p);
    Console.WriteLine(lambda.Compile()(list));
