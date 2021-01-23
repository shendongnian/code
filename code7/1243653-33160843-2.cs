    public void UpdateMarket (Market Market, int Id)
    {
        var ListP = MarketCookiesRepository.GetAll()
                    .Where(x => x.MarketID == Id && Market.State != "Inactive").ToList();
        var ListF = Market.Cookies.ToList();
        IEqualityComparer<Cookie> comparer = new GeneralEqualityComparer<Cookie>(
            (t1, t2) => t1.Id == t2.Id, t => t.Id.GetHashCode());
        foreach (var item in ListP.Except(ListF, comparer))
        {
            // set to inactive
        }
        foreach (var item in ListF.Except(ListP, comparer))
        {
            // create new object
        }
    }
