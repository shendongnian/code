        // Calls static method GetTime with no args
        var mCallGetTime = Expression.Call(typeof(MyClass), "GetTime", null);
        Func<string> resultNoArg = Expression.Lambda<Func<string>>(mCallGetTime).Compile();
        
        // The input param for GetName which is of type Type
        var paramExp = Expression.Parameter(typeof(Type));
        
        // Calls static method GetName passing in the param
        var mCallGetName = Expression.Call(typeof(MyClass), "GetName", null, paramExp);
        Func<Type, string> resultWithArg = Expression.Lambda<Func<Type, string>>(mCallGetName, paramExp).Compile();
        
        // You can then call them like so... Print() just prints the string
        resultNoArg().Print();
        resultWithArg(typeof(string)).Print();
        resultWithArg(typeof(int)).Print();
