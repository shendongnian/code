    public class BaseObjectConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
            where TEntity : BaseObject
    {
            public BaseObjectConfiguration()
            {
                // Mapped
                HasKey(t => t.Id);
                Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.Name).IsRequired().HasMaxLength(100);
                Property(t => t.DisplayName).IsOptional().HasMaxLength(100);
                Property(t => t.Alias).IsOptional().HasMaxLength(100);
                Property(t => t.SourceId).IsRequired();
                Property(t => t.AccessLevel).IsRequired();
                Property(t => t.CreatedOn).IsOptional();
                Property(t => t.CreatedBy).IsOptional().HasMaxLength(50);
                Property(t => t.ModifiedOn).IsOptional();
                Property(t => t.ModifiedBy).IsOptional().HasMaxLength(50);
    
                //// Base Entity Ignores (Not Mapped)
                Ignore(t => t.SomeIgnoredProperty);
                Ignore(t => t.SomeIgnoredProperty2);
                Ignore(t => t.SomeIgnoredProperty3);
            }
    }
