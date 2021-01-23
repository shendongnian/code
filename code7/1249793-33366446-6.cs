    public static class Helper
    {
        static Dictionary<string, Type> _types = new Dictionary<string, Type>()
        {
            {"int", typeof(int)}, {"string", typeof(string)}, 
            {"double", typeof(double)}, {"decimal", typeof(decimal)},             
            // ... etc
        };
    
        public static bool Is<T>(this T instance, params string[] types)
        {
            Type iType = instance.GetType();
            for (int i = 0; i < types.Length; i++)
                if (_types.ContainsKey(types[i]) && _types[types[i]] == iType)
                    return true;
            return false;
        }
    }
    
