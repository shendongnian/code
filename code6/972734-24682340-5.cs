    [SuppressMessage("Microsoft.Contracts", "Invariant")]
    //or this: [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods")]
    public ActionResult Index()
    {
        Contract.Requires(Request != null);
        //...
        return View();
    }
