    public class Mine : ThatAbstractClass
    {
      Dictionary<string, dynamic> IndexerValues = new Dictionary<string, dynamic>();
    
      public override dynamic this[string key]
      {
        get { return IndexerValues[key]; }
        set { IndexerValues[key] = value; }
      }
    }
