    public ActionResult DisplayModel()
            {
                ExpandoObject yourModel = new ExpandoObject();
                List<Teacher> listofteachers = dbh.GetTeachers();
                List<student> listofstudents = dbh.Students();
    
                mymodels.ListTeachers = listofteachers;
                mymodels.ListStudents = listofstudents;
    
                return View("ModelView", yourModel );
            }
