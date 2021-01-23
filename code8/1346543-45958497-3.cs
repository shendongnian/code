    public class EntityBaseConfiguration<TBase> : IEntityTypeConfiguration<TBase>
        where TBase : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreatedBy)
                .HasColumnType("varchar(50)");
            builder.Property(b => b.CreatedAt)
                .HasColumnType("datetime2");
        }
    }
