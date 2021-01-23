    public override int SaveChanges()
    {
        return SaveChangesWrapper<int>(() => base.SaveChanges());
    }
    public override async Task<int> SaveChangesAsync()
    {
        return await SaveChangesWrapper<Task<int>>(async () => await base.SaveChangesAsync());
    }
