    abstract class BaseEntityMapping : EntityTypeConfiguration<BaseEntity>
    {
        public BaseEntityMapping()
        {
            this.Ignore(t => t.X);
            this.Ignore(t => t.Y);
        }
    }
    class CalendarMapping : BaseEntityMapping
    {
        public CalendarMapping()
        {
            // Specific mappings
        }
    }
