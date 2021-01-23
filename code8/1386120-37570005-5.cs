    AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab =
                AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb =
                ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
            TypeBuilder tb = mb.DefineType("MyClass", TypeAttributes.Public);
            MethodBuilder meb = tb.DefineMethod("Foo", MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(void), new Type[] { typeof(TimeSpan) });
            ParameterBuilder pb = meb.DefineParameter(1, ParameterAttributes.Optional | ParameterAttributes.HasDefault, "ts");
            MethodInfo getNativeHandle = typeof(ModuleBuilder).GetMethod("GetNativeHandle", BindingFlags.NonPublic | BindingFlags.Instance);
            object nativeHandle = getNativeHandle.Invoke(mb, new object[0]);
            int tk = pb.GetToken().Token;
            MethodInfo setConstantValue = typeof(TypeBuilder).GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(mi => mi.Name == "SetConstantValue" && mi.GetParameters().Last().ParameterType.IsPointer).First();
            setConstantValue.Invoke(pb, new object[] { nativeHandle, tk, /* CorElementType.Class: */ 18, null });
            ILGenerator ilgen = meb.GetILGenerator();
            FieldInfo fi = typeof(ILGenerator).GetField("m_maxStackSize", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(ilgen, 8);
            ilgen.Emit(OpCodes.Ret);
            tb.CreateType();
            ab.Save("DynamicAssemblyExample.dll");
