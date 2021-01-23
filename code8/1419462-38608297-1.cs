    public sealed class Lookup
    {
      private readonly Expression parent;
    
      private Lookup(Expression parent)
      {
        this.parent = parent;
      }
    
      public Expression Parent { get { return parent; } }
    
      public static Lookup For<T>(Expression<Func<T, object>> member)
        where T : BaseEntity
      {
        return new Lookup(member);
      }
    }
