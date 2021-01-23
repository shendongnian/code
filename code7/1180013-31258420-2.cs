    public class YourClassMap : EntityTypeConfiguration<YourClass>
    {
        public YourClassMap()
        {
            this.Property(t => t.AAA).IsRequired();
            //Here you can specify the PK of your entity, relationships,...
        }
    }
