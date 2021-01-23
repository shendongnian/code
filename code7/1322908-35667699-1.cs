        public Configuration(bool automaticMigrationsEnabled = false)
        {
            AutomaticMigrationsEnabled = automaticMigrationsEnabled;
            ContextKey = "Project.DAL.ApplicationDbContext";
        }
