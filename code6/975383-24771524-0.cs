    public class SeedOnlyInitializer : IDatabaseInitializer<YourContextType>  {
        public void InitializeDatabase(YourContextType context)
        {
            Seed.Execute(context);
            context.SaveChanges();
        } 
    }
