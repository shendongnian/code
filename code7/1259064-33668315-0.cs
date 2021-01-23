            object o = new List<double>();
            Type t = o.GetType();
            if (t.IsGenericType 
                && t.GetGenericTypeDefinition() == typeof(List<>) 
                && t.GenericTypeArguments.Length == 1)
            {
                    Console.WriteLine("This is a list of type {0}", t.GenericTypeArguments[0].Name);
            }
