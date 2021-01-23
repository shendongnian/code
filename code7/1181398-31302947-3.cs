    public void InitializeDatabase(MyRepository context) {
                if (!context.Database.Exists() || !context.Database.ModelMatchesDatabase()) {
                    context.Database.DeleteIfExists();
                    context.Database.Create();
    
                    context.ObjectContext.ExecuteStoreCommand("CREATE UNIQUE CONSTRAINT...");
                    context.ObjectContext.ExecuteStoreCommand("CREATE INDEX...");
                    context.ObjectContext.ExecuteStoreCommand("ETC...");
                }
            }
