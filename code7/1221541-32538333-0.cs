    public class A 
    {
      public virtual Guid id;
      public virtual string name;
    }
    public class B : A { }
    public class AMap : ClassMap<A>
    {
      public AMap()
      {
        Table("Atable");
        Id(x => x.id);
        Map(x => x.name);
      }
    }
    public class BMap : SubclassMap<B>
    {
      public BMap()
      {
        Table("Btable");
      }
    }
