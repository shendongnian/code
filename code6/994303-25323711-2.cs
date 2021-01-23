    public class YourMagicClass
    {
        private static readonly Dictionary<FunctionType, MethodInfo> FunctionTypeToMethod =
            typeof (ExecuteFunction).
                GetMethods(BindingFlags.Public | BindingFlags.Static)
                                    .Where(x => x.IsDefined(typeof (CallMethodAttribute)))
                                    .Select(x => new
                                        {
                                            Method = x,
                                            FunctionType = x.GetCustomAttribute<CallMethodAttribute>().FunctionType
                                        })
                                    .ToDictionary(x => x.FunctionType, x => x.Method);
        public static string SomeMagicMethod(FunctionType functionType, int a, int b)
        {
            MethodInfo method;
            
            if (!FunctionTypeToMethod.TryGetValue(functionType, out method))
            {
                throw new ArgumentException("Could not find a handler for the given function type", "functionType");
            }
            else
            {
                string result = (string)method.Invoke(null, new object[] { a, b });
                return result;
            }
        }
    }
