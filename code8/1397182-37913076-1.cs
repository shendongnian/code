    public ActionResult Index()
      { 
         ServiceReference1.ServiceClient obj = new ServiceReference1.ServiceClient();
         return View(obj.GetStudents().ToList()); 
      }
