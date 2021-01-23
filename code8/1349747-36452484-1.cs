    [HttpPost]    
    public ActionResult Index(YourModel yourModel)
    {
        var from = yourModel.FromDate;
        var to = yourModel.ToDate;
    }
