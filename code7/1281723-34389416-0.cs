     #region Needed For migrations
            private static string ConnectionStringForMigration()
            {
                return ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            }
    
            public MyContext()
                : base(MyContext.ConnectionStringForMigration())
            {
    
            } 
            #endregion
