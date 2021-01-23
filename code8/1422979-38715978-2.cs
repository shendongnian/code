    public JsonResult GetLatestNews()
    {
        //Write the query here to get the latest items...
        List<Quote> quotes = dbContext.quotes.ToList();
        return Json(quotes, JsonRequestBehavior.AllowGet);
    }
