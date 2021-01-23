    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
        try
        {   
            Student student = new Student();
    
            student.FirstName = collection["FirstName"];
            student.LastName = collection["LastName"];
            DateTime suppliedDate;
            DateTime.TryParse(collection["DOB"], out suppliedDate);
            student.DOB = suppliedDate;
            student.FathersName = collection["FathersName"];
            student.MothersName = collection["MothersName"];
    
            studentsList.Add(student);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
