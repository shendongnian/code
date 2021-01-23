    /// <summary>
    /// Base class
    /// </summary>
    public class BaseClass
    {
	  public BaseClass()
	  {
	  }
      public string Id { get; set; }
      public string Value { get; set; }
      public virtual List<BaseClass> GetClass();
    
      protected List<TClass> GetList<TClass> (Dictionary<string, string> s) where TClass : BaseClass, new() {
        List<TClass> _s = new List<TClass>();
        foreach (var item in s)
        {
            TClass c = new TClass();
            c.Id = item.Key;
            c.Value = item.Value;
            _s.Add(c);
        }
        return _s;
      }
    }
    public class Class1 : BaseClass
      {
        public override List<Class1> GetClass() {
           Dictionary<string, string> s = GetSomeResults1();
           return GetList<Class1>(s);
      }
    }
