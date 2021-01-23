    class ContextInitializer : DropCreateDatabaseIfModelChanges<Dbc>
    {
        protected override void Seed(Dbc context)
        {
            // Here you can notify you before any change got executed
            InitializeDatabase(context);
        }
    }
