    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            WithTable("items");
            Id(x => x.Id); // add Id generation cfg if needed
            HasMany(x => x.Resources)
                .Inverse()
                .Cascade.All()
        }
    }
    public class ResourceMap : ClassMap<Resource>
    {
        public ResourceMap()
        {
            WithTable("resources")
            CompositeId()
                .KeyProperty(x => x.ResourceId)
                .KeyProperty(x => x.Locale);
            References(x => x.Owner)
        }
    }
