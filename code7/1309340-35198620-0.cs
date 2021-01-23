    public static class DbAccessor
    {
        public static string ConnectionStringForDBOne { get { return ConfigurationManager.ConnectionStrings["DBOne"].ConnectionString} }
        public static string ConnectionStringForDBTwo { get { return ConfigurationManager.ConnectionStrings["DBTwo"].ConnectionString} }
    }
