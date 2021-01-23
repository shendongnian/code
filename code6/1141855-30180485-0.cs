    [HttpGet]
    [Page("View1")]
    public virtual ActionResult Index()
    {
        model1 = new Model();           
        return this.View(model1);
    }
