    [HttpPost]    
    public ActionResult GetDates(YourModel yourModel)
    {
        var from = yourModel.FromDate;
        var to = yourModel.ToDate;
    }
