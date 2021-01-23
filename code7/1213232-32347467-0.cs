    internal class AMap : ClassMap<A>
    {
        internal AMap()
        {
            Id(x => x.ID).GeneratedBy.Assigned().Not.Nullable();
            Map(x => x.Name).Length(255);
            
            Map(x => x.Type).Column("ObjType");
            DiscriminateSubClassesOnColumn(@"Type");
            Table("A");
        }
    }
    internal class BMap : SubclassMap<B>
    {
        internal BMap()
        {
            HasManyToMany(x => x.Cities).Not.LazyLoad().AsBag().Table("B").Cascade.All();
        }
    }
