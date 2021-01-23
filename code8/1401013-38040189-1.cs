    public ActionResult SomeAction(string id) {
    
    	var query = from fac in db.SemesterByFaculty
    		        join sem in db.Semester on fac.SemesterID equals sem.ID
    		        where fac.FacultyID == id
    		        select new MyModel{ Faculty = fac, SemesterTest = sem.SemesterTest };
    
        var viewModel = new MyViewModel { SemesterFaculties = query.ToList() };
        return View(viewModel);
    }
