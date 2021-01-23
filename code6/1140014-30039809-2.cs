    public static class MyContext
    {
      private static readonly string name = Guid.NewGuid().ToString("N");
      private sealed class Wrapper : MarshalByRefObject
      {
        public Guid Value { get; set; }
      }
      public static Guid CurrentContext
      {
        get
        {
          var ret = CallContext.LogicalGetData(name) as Wrapper;
          return ret == null ? Guid.Empty : ret.Value;
        }
        set
        {
          CallContext.LogicalSetData(name, new Wrapper { Value = value });
        }
      }
    }
