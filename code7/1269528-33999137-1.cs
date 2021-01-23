    public class AMap : ClassMap<A>
    {
        public AMap()
        {
            Table("A");
            Id(x => x.Id).Column("Id");
            Map(x => x.messageA);
            HasMany(x => x.Bs).Cascade.All();
        }
    }
    public class BMap : ClassMap<B>
    {
        public BMap()
        {
            Table("B");
            Id(x => x.Id).Column("Id"); ;
            Map(x => x.messageB);
            HasMany(x => x.Cs).Cascade.All();
        }
    }
    public class CMap : ClassMap<C>
    {
        public CMap()
        {
            Table("C");
            Id(x => x.Id).Column("Id"); ;
            Map(x => x.messageC);
        }
    }
