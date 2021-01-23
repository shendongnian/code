    var temp1 = Expression.Variable(typeof(string), "temp1");
    
    //use int.Parse(string) here
    var parseMethod = typeof(int).GetMethod("Parse", new[] { typeof(string) }); 
    var gt = Expression.GreaterThan(Expression.Call(parseMethod, temp1), Expression.Constant(1));
