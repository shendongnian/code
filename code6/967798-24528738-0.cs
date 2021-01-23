    public virtual void InitializeDatabase(TContext context)
    {
        Check.NotNull<TContext>(context, "context");
        context.Database.Delete();
        context.Database.Create(DatabaseExistenceState.DoesNotExist);
        this.Seed(context);
        context.SaveChanges();
    }
