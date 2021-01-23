    public class PersonConfig : BaseConfig<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
