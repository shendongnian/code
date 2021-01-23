    public ActionResult Index() // To Show the Main Movie Page
    {
        return View();
    }
    Public ActionResult ShowDetail(int id) //To Show Detail information
    {
        // Do the Database operations to retrive movie information
        return Content("This is my Detail information");
    }
