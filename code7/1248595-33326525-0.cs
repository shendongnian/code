    public static class Extensioin
    {
        public static string MyTryParse(this string[] args, string defaultVal)
        {
            return args.Length > 0 ? args[0] : defaultVal;
        }
    }
