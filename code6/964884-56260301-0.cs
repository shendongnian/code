    http://localhost:60386//Home/Create
   
    @using (Html.BeginForm("Create", "Home", FormMethod.Post))
    {
      @Html.EditorFor(model => model.FirstName)
    
      <input type="submit" value="Create"/>
    }
        
    HomeController.cs:
            [HttpPost]
            public ActionResult Create(Person person)
            {
                
                if (ModelState.IsValid)
                {
                    db.Persons.Add(person);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
    
                return View(person);
            }
