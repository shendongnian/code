        private static int GenericD(object[] paramArray, MethodBase caller)
        {
            var paramTypes = caller.GetParameters().Select(x => x.ParameterType);
            var method = typeof(Static.A).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                .Where(m => m.Name == "B" && m.GetParameters().Select(x => x.ParameterType).SequenceEqual(paramTypes))
                .FirstOrDefault();
            if (method != null)
            {
                return (int)method.Invoke(null, paramArray);
            }
            throw new Exception("Overloaded method not found");
        }
        public static int D(string p)
        {
            object[] paramArray = new object[] { p };
            return GenericD(paramArray, MethodInfo.GetCurrentMethod());
        }
        public static int D(string p, int x)
        {
            object[] paramArray = new object[] { p, x };
            return GenericD(paramArray, MethodInfo.GetCurrentMethod());
        }
