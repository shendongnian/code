    public Configuration()
        {
            // This ensures a schema diff. is always performed and automatic updates take place.
            AutomaticMigrationsEnabled = true;
            var dbMigrator = new DbMigrator(this);
            // This is required to detect changes.
            pendingMigrationsExist = dbMigrator.GetPendingMigrations().Any();
            if (pendingMigrationsExist)
            {
                dbMigrator.Update();
            }
        }
