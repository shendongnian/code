    class Program
    {
        static MethodAttributes attrs = MethodAttributes.Public | MethodAttributes.RTSpecialName | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
        static Type CreateType() {
            var myDomain = Thread.GetDomain();
            var myAsmName = new AssemblyName { Name = "Demo" };
            var myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave);
            var moudle = myAsmBuilder.DefineDynamicModule("DemoModule", "Demo.dll");
            var typeBuilder = moudle.DefineType("MyClass", TypeAttributes.Public | TypeAttributes.BeforeFieldInit);
            var fieldBuilder = typeBuilder.DefineField("myField", typeof(MyField), FieldAttributes.Private);
            var ctorBuilder = typeBuilder.DefineConstructor(attrs, CallingConventions.HasThis | CallingConventions.Standard, Type.EmptyTypes);
            var methodBuilder = typeBuilder.DefineMethod("MyMethod", MethodAttributes.Public | MethodAttributes.HideBySig, typeof(int), new[] { typeof(int) });
            var ctorILGen = ctorBuilder.GetILGenerator();
            var ilGen = methodBuilder.GetILGenerator();
            var someMethod = fieldBuilder.FieldType.GetMethod("SomeMethod");
            ctorILGen.Emit(OpCodes.Ldarg_0);
            ctorILGen.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            ctorILGen.Emit(OpCodes.Ldarg_0);
            ctorILGen.Emit(OpCodes.Newobj, fieldBuilder.FieldType.GetConstructor(Type.EmptyTypes));
            ctorILGen.Emit(OpCodes.Stfld, fieldBuilder);
            ctorILGen.Emit(OpCodes.Ret);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, fieldBuilder);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Callvirt, someMethod);
            ilGen.Emit(OpCodes.Ret);
            return typeBuilder.CreateType();
        }
        static void Main(string[] args) {
            var type = CreateType();
            dynamic instance = Activator.CreateInstance(type);
            Console.WriteLine(instance.MyMethod(10));
        }
    }
