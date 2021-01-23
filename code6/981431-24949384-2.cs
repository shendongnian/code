    public static class MethodWarmerUper
    {
        public static void WarmUp(string methodName)
        {
            var handle = FindMethodWithName(methodName).MethodHandle;
            RuntimeHelpers.PrepareMethod(handle);
        }
    
        private static MethodInfo FindMethodWithName(string methodName)
        {
            return 
                Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .SelectMany(type => type.GetMethods(MethodBindingFlags))
                        .FirstOrDefault(method => method.Name == methodName);
        }
    
        private const BindingFlags MethodBindingFlags =
            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static;
    }
