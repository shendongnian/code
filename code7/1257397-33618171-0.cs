        public MyAppEntities(String connString)
            : base(BuildConnectionString("SERVERNAME", "DATABASE"))
        {
        }
        public MyAppEntities()
            : base("name=MyAppEntities")
        {
        }
