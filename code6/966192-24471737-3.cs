        public static T CreateInstance<T>(params object[] Params) where T : class // params keyword for array
        {
            List<Type> argTypes = new List<Type>();
            //used .GetType() method to get the appropriate type
            //Param can be null so handle accordingly
            foreach (object Param in Params)
                argTypes.Add((Param ?? new object()).GetType());
            ConstructorInfo[] Types = typeof(T).GetConstructors();
            foreach (ConstructorInfo node in Types)
            {
                ParameterInfo[] Args = node.GetParameters();
                if (Params.Length == Args.Length)
                {
                    bool[] cond = new bool[Params.Length];
                    //handle derived types
                    for (int i = 0; i < Params.Length; i++)
                        if (Args[i].ParameterType.IsAssignableFrom(argTypes[i])) cond[i] = true;
                    if (cond[0] && cond[1])
                        return (T)node.Invoke(Params);
                }
            }
            return default(T);
        }
