    public static class MyConfig
    {
        public static string ECS;
        static MyConfig()
        {
            string srcConnectionString = System.Configuration.ConfigurationManager.
                 ConnectionStrings["connectionStringName"].ConnectionString;
            EntityConnectionStringBuilder sb = new EntityConnectionStringBuilder(srcConnectionString);
            ECS = sb.ToString();
        }
    }
