    void Main()
    {
      var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("TestAssembly"), AssemblyBuilderAccess.Run);
      var mb = ab.DefineDynamicModule("Test");
      
      var tb = mb.DefineType("Foo");
      tb.AddInterfaceImplementation(typeof(IFoo));
      
      foreach (var imethod in typeof(IFoo).GetMethods())
      {
        var valueString = ((DescriptionAttribute)imethod.GetCustomAttribute(typeof(DescriptionAttribute))).Description;
        
        var method = 
          tb.DefineMethod
          (
            "@@" + imethod.Name, 
            MethodAttributes.Private | MethodAttributes.Static, 
            imethod.ReturnType,
            new [] { tb }
          );
        
        // Needless to say, I'm making a lot of assumptions here :)
        var thisParameter = Expression.Parameter(typeof(IFoo), "this");
        
        var bodyExpression =
          Expression.Lambda
          (
            Expression.Constant
            (
              Convert.ChangeType(valueString, imethod.ReturnType)
            ),
            thisParameter
          );
        
        bodyExpression.CompileToMethod(method);
        
        var stub =
          tb.DefineMethod(imethod.Name, MethodAttributes.Public | MethodAttributes.Virtual, imethod.ReturnType, new Type[0]);
          
        var il = stub.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.EmitCall(OpCodes.Call, method, null);
        il.Emit(OpCodes.Ret);
            
        tb.DefineMethodOverride(stub, imethod);
      }
      
      var fooType = tb.CreateType();
      var ifoo = (IFoo)Activator.CreateInstance(fooType);
      
      Console.WriteLine(ifoo.Bar()); // 5
      Console.WriteLine(ifoo.Baz()); // True
    }
    
    public interface IFoo
    {
        [Description("5")]
        int Bar();
        [Description("true")]
        bool Baz();
    }
