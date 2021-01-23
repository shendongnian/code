    public virtual void InitializeDatabase(TContext context)
    {
        Check.NotNull(context, "context");
        var existence = new DatabaseTableChecker().AnyModelTableExists(context.InternalContext);
        if (existence == DatabaseExistenceState.Exists)
        {
            // If there is no metadata either in the model or in the database, then
            // we assume that the database matches the model because the common cases for
            // these scenarios are database/model first and/or an existing database.
            if (!context.Database.CompatibleWithModel(throwIfNoMetadata: false, existenceState: existence))
            {
                throw Error.DatabaseInitializationStrategy_ModelMismatch(context.GetType().Name);
            }
        }
        else
        {
            // Either the database doesn't exist, or exists and is considered empty
            context.Database.Create(existence);
            Seed(context);
            context.SaveChanges();
        }
    }
