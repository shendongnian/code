    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    	modelBuilder.Entity<TemplatesMaps>().HasRequired(o => o.Template).WithMany().Map(m => m.MapKey("TemplateId"));
    	modelBuilder.Entity<TemplatesMaps>().HasOptional(o => o.Employee).WithMany().Map(m => m.MapKey("EmployeeId"));
    	modelBuilder.Entity<TemplatesMaps>().HasOptional(o => o.User).WithMany().Map(m => m.MapKey("UserId"));
    	base.OnModelCreating(modelBuilder);
    }
