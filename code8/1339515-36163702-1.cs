    public ActionResult Details(string id, string sortOrder)
    {
        // don't know what logic stands behind these ViewBag usages.
        // maybe you should get rid of them
        ViewBag.CurrentSort = sortOrder;
        ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        // changes start
        Person person = db.Persons.Include(x => x.Sessions).Find(id);
        if (person == null)
            return HttpNotFound();
        person.Sessions = sortOrder == "date_desc" ? 
            person.Sessions.OrderByDescending(s => s.training).ToList() : 
            person.Sessions.OrderBy(s => s.training).ToList();
        // changes end
        return View(person);
    }
