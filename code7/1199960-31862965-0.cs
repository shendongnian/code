        public static object Invoke(this ConstructorInfo constructor, Dictionary<string, object> parameters)
        {
            List<object> parameterValues = new List<object>();
            foreach(var parameterInfo in constructor.GetParameters())
            {
                if (parameters.ContainsKey(parameterInfo.Name))
                    parameterValues.Add(parameters[parameterInfo.Name]);
                else
                    parameterValues.Add(null);
            }
            return constructor.Invoke(parameterValues.ToArray());
        }
