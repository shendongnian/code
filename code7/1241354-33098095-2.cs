    public class ChangedModelConfiguration : EntityTypeConfiguration<ChangedModelName>
        {
            public ChangedModelConfiguration()
            {
                ToTable("SameTableName", "YourSchemaName");
            }
        }
