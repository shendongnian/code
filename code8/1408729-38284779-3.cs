    public ActionResult Index()
        {
           
            StudensP_Registration oc = new StudensP_Registration();
            oc.studentsp = db.StudentsProfile;
            oc.registration = db.Registration;
            return View(oc);
        }
