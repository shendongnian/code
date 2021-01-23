    public class CustomContextInitializer : IDatabaseInitializer<CustomProjectContext>
    {        
        public void InitializeDatabase(CustomProjectContext context)
        {
            context.Database.Initialize(false);
        }
    }
