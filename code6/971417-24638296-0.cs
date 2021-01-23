    public ActionResult PopulateData()
    {        
        for(int i=0;i<2;i++)
        {
            Student objStu = new Student();
            objStu.ID = i+1;
            objStu.name = "something";
            db.Students.Add(objStu);
            db.SaveChanges();
        }
        return View();
    }
