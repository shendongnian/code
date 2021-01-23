    public static T CreateAdapter<T>(Type staticClassType)
    {
        AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(typeof(T).Name + "Adapter"),
            AssemblyBuilderAccess.RunAndSave);
        ModuleBuilder mb = ab.DefineDynamicModule(typeof(T).Name + "Adapter.dll");
        // public class TAdapter : T
        TypeBuilder tb = mb.DefineType(typeof(T).Name + "Adapter", TypeAttributes.Public | TypeAttributes.Class,
            typeof(object), new Type[] { typeof(T) });
        // creating methods
        foreach (var methodInfo in typeof(T).GetMethods())
        {
            var parameters = methodInfo.GetParameters();
            var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();
            var method = tb.DefineMethod(methodInfo.Name,
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
                methodInfo.ReturnType, parameterTypes);
            // adding parameters
            for (int i = 0; i <parameters.Length; i++)
            {
                method.DefineParameter(i + 1, parameters[i].Attributes, parameters[i].Name);
            }
            // calling the static method from the body and returning its result
            var staticMethod = staticClassType.GetMethod(methodInfo.Name, parameterTypes);
            var code = method.GetILGenerator();
            for (int i = 0; i < parameters.Length; i++)
            {
                code.Emit(OpCodes.Ldarg_S, i + 1);
            }
            code.Emit(OpCodes.Call, staticMethod);
            code.Emit(OpCodes.Ret);
        }
        return (T)Activator.CreateInstance(tb.CreateType());
    }
}
