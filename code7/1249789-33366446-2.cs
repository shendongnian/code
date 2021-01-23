    public static class Helper
    {
        static Dictionary<string, Type> types = new Dictionary<string, Type>()
        {
           {"int", typeof(int)}, {"string", typeof(string)}, 
           {"double", typeof(double)}, {"decimal", typeof(decimal)}, 
           // ... etc
        };
        public static bool Is<T>(this T instance, param Type[] types)
        {
           Type t = instance.GetType();
           for(int i = 0; i < types.Length; i++)
             if(t == types[i]) return true;
           return false;
        }
    }
    
