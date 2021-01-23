    public class MyEntityMap : EntityTypeConfiguration<MyEntity>
    {
        public const string TableName = "CustomName";
    
        public ActionMap()
        {                   
            ToTable(TableName);
    
            Property(t => t.Id);
        }
    }
