    public class TestEntityMap : ClassMapping<TestEntity>
    {
        public TestEntityMap()
        {
            Id( x => x.unit_name, map =>
            {
                map.Column("user_name");
                map.Generator(Generators.Assigned);
            });
            Property(x => x.id, map =>
            {
                map.Generated(PropertyGeneration.Always);
                map.Unique(true);
                map.NotNullable(true);
            });
        }
    }
