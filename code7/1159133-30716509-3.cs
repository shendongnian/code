    LazyFields.Configure<Test>()
        // We can use a type-safe lambda
        .SetProvider(x => x.Test1, inst => inst.Var1 + inst.Var2)
        // Or the field name.
        .SetProvider("Test2", TestMethod2);
    var x = new Test() { Var1 = 20, Var2 = 30 };
    Console.WriteLine(x.Test1);
    double test2Val = x.Test2; // type-safe conversion
    Console.WriteLine(test2Val);
    // Output:
    // 50
    // -10
    
