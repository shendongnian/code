     public class marketIds
    {
        public int x_market_code { get; set; }
    }
    
        [HttpPost]
        [Route("getAssignedMarkets")]
        public IQueryable GetAssignedMarkets(marketIds[] arry)
        {
          return db.markets.Where(x => arry.where(t=>t.x_market_code == x.x_market_code).Any());
        }
