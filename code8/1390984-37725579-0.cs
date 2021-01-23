    var x = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(t)
        .Invoke(null, new object [] { gv.Items });
    
    var y = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(t)
        .Invoke(null, new object[] { x });
