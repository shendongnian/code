    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Name,ServiceNeeded")] Person person, List<String> ServiceNeeded)
    {
        if (ModelState.IsValid)
        {
         
            db.People.Add(person);
            db.SaveChanges();
            db.Entry(person).GetDatabaseValues();
             foreach (string service in ServiceNeeded){
                 db.MyServices.Add( new MyService {ServiceName = service,
                       PersonId = person.Id})
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(person);
    }
