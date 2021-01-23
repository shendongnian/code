    public static class TypeInfoEx
    {
        public static MethodInfo[] GetMethods(this TypeInfo type)
        {
            var methods = new List<MethodInfo>();
            while (true)
            {
                methods.AddRange(type.DeclaredMethods);
                Type type2 = type.BaseType;
                if (type2 == null)
                {
                    break;
                }
                type = type2.GetTypeInfo();
            }
            return methods.ToArray();
        }
    }
