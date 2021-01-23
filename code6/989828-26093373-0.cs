    public class ClassA
    {
        public virtual int Id1 {get;set;}
        public virtual string Id2 {get;set;}
    
        public virtual IList<string> Bs { get; private set; }
    
        public override int GetHashCode()
        {
            return (Id1 << 16) ^ Id2.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            var toCompare = obj as ClassA;
    
            return (toCompare != null) && (this.Id1 == toCompare.Id1) && (this.Id2 == toCompare.Id2);
        }
    }
    
    public class ClassAMap : ClassMap<ClassA>
    {
        public ClassAMap()
        {
            Schema("dbo");
    
            Table("ClassA");
    
            Not.LazyLoad();
    
            CompositeId()           
                .KeyProperty(x => x.Id1, "a_1_id")
                .KeyProperty(x => x.Id2, "a_2_id");
    
            HasMany(x => x.ClassBs)
                .AsSet()
                .Table("ClassB")
                .KeyColumn("a_2_id")
                .Not.LazyLoad(),
                .Element("b_field1");  // if there is only 1 value column or
                .Component(c =>        // if there is more than 1 value column
                {
                    c.ParentReference(x => x.A);
                    c.Map(x => x.Value1, "b_field1");
                    c.Map(x => x.Value2, "b_field2");
                    c.Map(x => x.Value3, "b_field3");
                });
        }
    }
    
    public class ClassB
    {
        public virtual ClassA A {get;set;}
        public virtual string Value1 {get;set;}
        public virtual string Value2 {get;set;}
        public virtual string Value3 {get;set;}
    }
