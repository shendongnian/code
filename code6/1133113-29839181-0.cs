    public class FooBar
    {
        public virtual int FooBarId { get; set; }
        public virtual string FooBarName { get; set; }
    }
    
    public class FooBarMap : ClassMap<FooBar>
    {
        public FooBarMap()
        {
            Table("foorbar");
            LazyLoad();
            Id(x => x.FooBarId).GeneratedBy.Identity().Column("foobar_id");
            Map(x => x.FooBarName);
        }
    }
    
    public class Bar
    {
        public virtual int BarId {get; set;}
        public virtual FooBar FooBar {get; set;}
        public virtual string BarName { get; set; }
    }
    
    public class BarMap : ClassMap<Bar>
    {
        public BarMap()
        {
            Table("bar");
            LazyLoad();
            Id(x => x.BarId).GeneratedBy.Identity().Column("bar_id");
            Map(x => x.BarName);
            References(x => x.FooBar).Column("foo_bar").Not.LazyLoad();
        }
    }
    
    public class Baz
    {
        public virtual int BazId {get; set;}
        public virtual string BazName { get; set; }
    }
    
    public class BazMap : ClassMap<Baz>
    {
        public BazMap()
        {
            Table("baz");
            LazyLoad();
            Id(x => x.BazId).GeneratedBy.Identity().Column("baz_id");
            Map(x => x.BazName);
        }
    }
    
    public class Foo
    {
        public virtual int FooId { get; set; }
        public virtual Bar Bar { get; set; }
        public virtual Baz Baz { get; set; }
        public virtual string FooName { get; set; }
    }
    
    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            Table("foo");
            LazyLoad();
            Id(x => x.FooId).GeneratedBy.Identity().Column("foo_id");
            Map(x => x.FooName);
            References(x => x.Bar).Column("bar").Not.LazyLoad();
            References(x => x.Baz).Column("baz").Not.LazyLoad();
        }
    }
