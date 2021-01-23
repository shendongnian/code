    [Test]
    public void LambdaTest2()
    {
        var asm = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("test"), AssemblyBuilderAccess.Run);
        var masm = asm.DefineDynamicModule("main");
        var type = masm.DefineType("TestType");
        var mb = type.DefineMethod("TestMethod", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new Type[0]);
        // your lambda
        ConstantExpression expressionTree = Expression.Constant(0);
        Expression.Lambda(typeof(Func<int>), expressionTree).CompileToMethod(mb);
        var m = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), type.CreateType().GetMethod("TestMethod"));
        Assert.That(m.Method.DeclaringType, Is.Not.Null);
        // you can create another in the same module but with another type (because type can't be changed)
        var type2 = masm.DefineType("TestType2");
        var mb2 = type2.DefineMethod("TestMethod2", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new Type[0]);
        // your lambda 2
        ConstantExpression expresisonTree2 = Expression.Constant(1);
        Expression.Lambda(typeof(Func<int>), expresisonTree2).CompileToMethod(mb2);
        var m2 = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), type2.CreateType().GetMethod("TestMethod2"));
        Assert.That(m2.Method.DeclaringType, Is.Not.Null);
        // check correctness
        Assert.That(m(), Is.EqualTo(0));
        Assert.That(m2(), Is.EqualTo(1));
    }
