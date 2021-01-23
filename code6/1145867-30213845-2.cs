     public partial class YourContext: DbContext
     {
         static YourContext()
         {
             Database.SetInitializer<YourContext>(new CreateDatabaseIfNotExists<YourContext>());
         }
     }
