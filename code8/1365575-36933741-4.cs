    public ActionResult Index()
    {
         // Please make use of a repository to handle this
         // You need to set up your data layer to handle students and professors
         SessionContext db = new SessionContext();
    
         ViewModel model = new ViewModel();
         
         // Get all the students
         model.Students = db.Students.ToList();
         // Get all the professors
         model.Professors = db.Professors.ToList()
    
         return View(model);
    }
