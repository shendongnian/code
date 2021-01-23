        public static object InvokeMethod(object obj, string name, object[] parameters)
        {
            var method = obj.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
            return method.Invoke(obj, parameters);
        }
