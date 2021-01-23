    public class Methods
    {
        public readonly Dictionary<string, Func<string[], object>> MethodsDict = new Dictionary<string, Func<string[], object>>();
        public Methods()
        {
            MethodsDict.Add("Method1", Method1);
            MethodsDict.Add("Method2", Method2);
        }
        public string Execute(string methodName, string[] strs)
        {
            Func<string[], object> method;
            if (!MethodsDict.TryGetValue(methodName, out method))
            {
                // Not found;
                throw new Exception();
            }
            object result = method(strs);
            // Here you should serialize result with your JSON serializer
            string json = result.ToString();
            return json;
        }
        public object Method1(string[] strs)
        {
            return strs.Length;
        }
        public object Method2(string[] strs)
        {
            return string.Concat(strs);
        }
    }
