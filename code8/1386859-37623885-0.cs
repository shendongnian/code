    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VLAN>()
                .HasOptional(vlan => vlan.Scope)
                .WithOptionalPrincipal();
            modelBuilder.Entity<VLAN>()
                .HasRequired(vlan => vlan.Group);
            modelBuilder.Entity<Scope>()
                .HasOptional(scope => scope.Vlan)
                .WithOptionalPrincipal();
            modelBuilder.Entity<Scope>()
                .HasRequired(scope => scope.Group);
            modelBuilder.Entity<Group>()
                .HasMany(group => group.Scopes);
            modelBuilder.Entity<Group>()
                .HasMany(group => group.Vlans);
    }
