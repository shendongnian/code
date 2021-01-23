    var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Test"), 
                                                         AssemblyBuilderAccess.Run);
    var module = assembly.DefineDynamicModule("Test");
    var type = module.DefineType("TestType");
    
    var methodBuilder = type.DefineMethod("MyMethod", MethodAttributes.Public 
                                                      | MethodAttributes.Static);
    methodBuilder.SetReturnType(typeof(decimal));
    
    Expression<Func<decimal>> decimalExpression = () => 42M;
    
    decimalExpression.CompileToMethod(methodBuilder);
    
    var t = type.CreateType();
    
    var result = (decimal)t.GetMethod("MyMethod").Invoke(null, new object[] {});
    
    result.Dump(); // 42 :)
