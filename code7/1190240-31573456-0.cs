    enum Environment
    {
        Local,
        NotLocal,
        AnotherOne
    }
    public class scan
    {
        public scan(Environment value) { }
        public scan(): this(Environment.Local) { }
        public scan(string s) : this(ParseEnum(s)) { }
       
        private static Environment ParseEnum(string s)
        {
            Environment value = (Environment)Enum.Parse(typeof(Environment), s);
            if (Enum.IsDefined(typeof(Environment), value))
                return value;
    
            return Environment.Local;
        }
    }
