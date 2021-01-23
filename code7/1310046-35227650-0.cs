    public override async Task<int> SaveChangesAsync()
    {
        try
        {
            await AuditChanges(new[] { EntityState.Modified, EntityState.Deleted });
            var result = await base.SaveChangesAsync();
            await AuditChanges(new[] { EntityState.Added });
            return result;
        }
        catch (DbEntityValidationException ex) { throw ConstructDetailsFor(ex); }
    }
    
    async Task AuditChanges(EntityState[] states)
    {
        var auditableEntities = ChangeTracker.Entries<IAmAuditable>()
            .Where(e => states.Contains(e.State));
    
        foreach (var entry in auditableEntities)
            await Audit(entry);
    }
    
    async Task Audit(DbEntityEntry<IAmAuditable> entry)
    {
        ...
