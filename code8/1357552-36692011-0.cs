    public partial class PulseDbInitializer : IDatabaseInitializer<ApplicationDbContext>, IPulseDbInit
    {
      public void InitializeDatabase(ApplicationDbContext context)
      {
        var exists = new DatabaseTableChecker().AnyModelTableExists(context.InternalContext);
        if (exists == DatabaseExistenceState.Exists)
        {
           // maybe check if certain data exists and call the `Seed` method if
           // it doesn't
           return;
        }
        // Throw some error if it doesn't exist
      }
      
      protected override void Seed(ApplicationDbContext context)
      {
        _context = context;
        var pid = new PulseDbInitializionData(context);
        pid.Init(this);
      }
    }
