    [HttpPost]
    public JsonResult Create(HostViewModel model)
    {
        // Initialize a new Host data model and set its properties based on the view model
        var host = new Host()
        {
            Name = model.Name,
            ....
        }
        // Save it
        db.Hosts.Add(host); 
        db.SaveChanges();
        // Return its ID
        return Json(host.ID); // or return Json(null); if error
    }
