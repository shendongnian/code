    public ActionResult Index()
    {	
    	var List<string> students= new List<string>();
    	students.Add("Amanda");
    	students.Add("Heather");
    	students.Add("Jane");
    	students.Add("Jonh");
    	students.Add("Mark");         
    
    	ViewBag.DropDownStudent = new SelectList(students);
    	return View();
    }
