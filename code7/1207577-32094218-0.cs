    [HttpPost]
    public ActionResult _BoeingStockData()
    {
        var db = new SampleEntities();
        return Json(
            from s in db.Stocks
            where s.Symbol == "BA"
            select new StockDataPoint
            {
                Date = s.Date,
                Open = s.Open,
                High = s.High,
                Low = s.Low,
                Close = s.Close,
                Volume = s.Volume
            }
        );
    }
