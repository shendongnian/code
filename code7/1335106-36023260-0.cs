    public static class EntityBuilderHelper
    {
        public static void Map(this EntityTypeBuilder<MyEntity> entity)
        {
            entity.ForSqlServerToTable("MyEntityTable");
            entity.Property(e => e.Id)
                .HasColumnName("MyEntityTableId");
        }
    } 
