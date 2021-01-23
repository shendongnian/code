    public MethodBuilder BuildMethodset_StudentName(TypeBuilder type)
    {
        // Declaring method builder
        MethodBuilder method = type.DefineMethod("set_StudentName");
        // Preparing Reflection instances
        MethodInfo method1 = typeof(Program).GetMethod(
            "<set_StudentName>b__0", 
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
            null, 
            new Type[]{
                }, 
            null
            );
        ConstructorInfo ctor2 = typeof(System.Func<>).MakeGenericType(typeof(String)).GetConstructor(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
            null, 
            new Type[]{
                typeof(Object),
                typeof(IntPtr)
                }, 
            null
            );
        FieldInfo field3 = typeof(Program).GetField("studentName", BindingFlags.Public | BindingFlags.NonPublic);
        MethodInfo method4 = typeof(Program).GetMethod(
            "Set", 
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
            null, 
            new Type[]{
                typeof(System.Func<>).MakeGenericType(typeof(String)),
                typeof(String&),
                typeof(String)
                }, 
            null
            );
        // Method attributes
        method.Attributes = 
              System.Reflection.MethodAttributes.Public
            | System.Reflection.MethodAttributes.HideBySig;
        // Setting return type
        method.SetReturnType(typeof(Void));
        // Adding parameters
        method.SetParameters(
            typeof(String)
            );
        // Parameter value
        ParameterBuilder value =  method.DefineParameter(1, ParameterAttributes.None, "value");
        ILGenerator gen =  method.GetILGenerator();
        // Writing body
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldftn,method1);
        gen.Emit(OpCodes.Newobj,ctor2);
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldflda,field3);
        gen.Emit(OpCodes.Ldarg_1);
        gen.Emit(OpCodes.Call,method4);
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Ret);
        // finished
        return method;
    }
