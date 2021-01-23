    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //prefix "PE" on table name
        var pluralizationService = DbConfiguration.DependencyResolver.GetService<System.Data.Entity.Infrastructure.Pluralization.IPluralizationService>();
        modelBuilder.Types().Configure(entity => entity.ToTable("PE" + pluralizationService.Pluralize(entity.ClrType.Name)));
    }
