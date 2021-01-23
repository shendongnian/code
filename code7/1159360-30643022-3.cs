    public ActionResult Index()
    {
        string demo = Request.QueryString["MyNameSpace.ID"]; // get value from client
        Response.Cookies["MyNameSpace.ID"].Value = "server"; // change value in response
        return View();
    }
