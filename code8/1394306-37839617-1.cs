    internal class ObjectCMap : EntityTypeConfiguration<ObjectC>
    {
        public ObjectCMap()
        {
            this.HasOptional(o => o.ObjectA).WithMany(o => o.ObjectCCollection).WillCascadeOnDelete(false);
        }
    }
