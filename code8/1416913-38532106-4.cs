    public ActionResult Index(int id)
    {
        var addresses = db.Addresses.Include(a => a.Person)
            .Where(a => a.PersonID == id);
        Person person = db.People.Find(id);
        
        AddressIndexModel model = new AddressIndexModel();
        model.PersonID = id;
        model.FullName = person.FirstName + " " + person.LastName;
        model.Addresses = addresses.ToList();
      
        return View(model);
    }
