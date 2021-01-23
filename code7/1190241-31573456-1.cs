    public class scan
    {
        public scan(Environment value) { }
        public scan() : this(Environment.Local) { }
        public scan(string s) : this(ParseEnum(s)) { }
        private static Environment ParseEnum(string s)
        {
            // default to local
            Environment value = Environment.Local;
            // try parsing the string
            Enum.TryParse<Environment>(s, out value);
            // if sucessful, the new value will be returned
            // if not, Environment.Local will be returned
            return value;
        }
        public enum Environment
        {
            Local,
            NotLocal,
            AnotherOne
        }
    }
