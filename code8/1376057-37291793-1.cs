    public class FooMap : ClassMap<Foo>
    {
        public FooMap ()
        {
            Id(x => x.Id);
            HasMany(f => f.Bars).Inverse().Cascade.AllDeleteOrphans();
        }
    }
    public class BarMap : ClassMap<Bar>
    {
        public BarMap ()
        {
            Id(x => x.Id);
            References(x => x.Foo);
        }
    }
    
