    public static class debugging
    {
        public static List<string> cMsg = new List<string>();
    
        public static void add(String v)
        {
            cMsg.Add(v);
        }
    
        public static String get()
        {
            StringBuilder sbOnMe = new StringBuilder();
    
            foreach (var One in cMsg)
                sbOnMe.AppendLine(One);
    
            return sbOnMe.ToString();
        }
    }
