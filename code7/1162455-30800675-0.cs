        public virtual void InitializeDatabase(TContext context)
        {
            Check.NotNull(context, "context");
            context.Database.Delete();
            context.Database.Create(DatabaseExistenceState.DoesNotExist);
            Seed(context);
            context.SaveChanges();
        }
