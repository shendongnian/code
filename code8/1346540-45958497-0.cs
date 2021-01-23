    public class EntityBaseConfiguration<TBase> : IEntityTypeConfiguration<TBase>
        where TBase : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(base => base.Id);
            builder.Property(base => base.CreatedBy)
                .HasColumnType("varchar(50)");
            builder.Property(base => base.CreatedAt)
                .HasColumnType("datetime2");
        }
    }
