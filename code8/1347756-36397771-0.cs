     public ActionResult Index()
        {
            ViewBag.Message = "Welcome to my demo!";
            dynamic mymodel = new ExpandoObject();
            mymodel.Teachers = GetTeachers();
            mymodel.Students = GetStudents();
            return View(mymodel);
        }
