    public static class MyClass
    {
        public static string GetTime() 
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff");
        }
    
        public static string GetName(Type type)
        {
            return type.Name;
        }
    }
