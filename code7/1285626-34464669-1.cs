    [HttpPost]
    [Route("getAssignedMarkets")]
    public IQueryable GetAssignedMarkets(int[] arry)
    {
      return db.markets.Where(x => arry.Contains(x.x_market_code));
    }
