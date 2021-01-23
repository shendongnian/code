     public static class MyLogger
     {
        public static void Log(this object o, string format, params object[] par) 
        {
            string typeName = o.GetType().Name;
            string msg = string.Format(format, par);
            // Pass to logger
        }
     }
