    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<OrganizationUnit>(
                orgUnit =>
                {
                    orgUnit.HasOne(ou => ou.Parent)
                        .WithMany(ou => ou.Children)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasForeignKey(ou => ou.ParentId);
                });
            builder.Entity<OrganizationUnitMember>(member =>
            {
                member.HasAlternateKey(m => new {m.OrganizationUnitId, m.UserId});
            });
        }
