    public void UpdateMarket (Market Market, int Id)
    {
        var ListP = MarketCookiesRepository.GetAll()
                    .Where(x => x.MarketID == Id && Market.State != "Inactive").ToList();
        var ListF = Market.Cookies.ToList();
        foreach (var item in ListP.Except(ListF))
        {
            // set to inactive
        }
        foreach (var item in ListF.Except(ListP))
        {
            // create new object
        }
    }
