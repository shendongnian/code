    Type[] parameterTypes = { typeof(string), typeof(double) };
    var returnType = typeof(int);   
   
    var del = CreateDelegate(parameterTypes, returnType);
    
    //Output: System.Func`3[System.String,System.Double,System.Int32]
    del.GetType().Dump();
    
    //Output: 0
    del.DynamicInvoke("abc", 5D).Dump();
