    public class Portfolio
    {
      Shareholding.Factory ShareholdingFactory { get; set; }
      IList<Shareholding> _holdings = new List<Shareholding>();
      public Portfolio(Shareholding.Factory shareholdingFactory)
      {
        ShareholdingFactory = shareholdingFactory;
      }
      public void Add(string symbol, uint holding)
      {
        _holdings.Add(ShareholdingFactory(symbol, holding));
      }
    }
