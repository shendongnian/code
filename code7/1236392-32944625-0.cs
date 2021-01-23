    public class HighestMap : ClassMap<Highest>
    {
        public HighestMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasMany(x => x.Children)
                .KeyColumn("parent_id");
        }
    }
    public class MediumMap : ClassMap<Medium>
    {
        public MediumMap()
        {
            CompositeId()
                .KeyReference(x => x.Parent, "parent_id")
                .KeyProperty(x => x.Index, "indexColumn");
            HasMany(x => x.Children)
                .Component(c =>
                {
                    c.ParentReference(x => x.Parent);
                    c.Map(x => x.LowType);
                });
        }
    }
