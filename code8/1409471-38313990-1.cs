    public class Price
    {
      public string Symbol {get; set; }
      public double AskPrice{get; set; }
      public double BidPrice{get; set; }
      public string Exchange{get; set; }
    
      public Price Clone()
      {
        var result = new Price();
        result.Symbol = this.Symbol;
        result.AskPrice = this.AskPrice;
        result.BidPrice = this.BidPrice;
        result.Exchange = this.Exchange;
        return result;
      }
    }
    
    public class inputs 
    {
      public IList<Price> Prices {get; set; }
    }
    
    var inputs = new 
    {
    Prices = prices,
    };
    
    Price[] p = inputs.Prices.Where(x => x.Exchange == exchange).Select(x=> x.Clone()).ToArray();
    
    p.ForEach(x => x.AskPrice = 0);
