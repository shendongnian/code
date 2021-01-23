    public static class Helper
    {
        public static bool IsOfType<T>(this T instance, param Type[] types)
        {
           Type t = instance.GetType();
           for(int i = 0; i < types.Length; i++)
             if(t == types[i]) return true;
           return false;
        }
    }
    
