    public class Price 
    {
        // your fields
       public Price Clone()
       {
           return new Price
           {
               Symbol = this.Symbol,
               BidPrice = this.BidPrice,
               //etc.
           }
       }
    }
    var p = input.Prices.Where(x => x.Exchange == exchange).Select(x => x.Clone()).ToArray();
