    public static class My_Page_Base
    {
        private static RequestContext _RequestContext;
        public static RequestContext RequestContext
        {
            get { return _RequestContext; }
            set { _RequestContext = value; }
        }
        private static string _connectionString;
        public static string connectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
    }
