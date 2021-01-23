    public static void PrintEnum<T>()
            {
                Type t = typeof (T);
                if (t.IsGenericType)
                {
                    //Assume it's a nullable enum
                    t = typeof (T).GenericTypeArguments[0];
                }
                
                foreach (var E in Enum.GetValues(t))
                    Console.WriteLine(E.ToString());
            }
