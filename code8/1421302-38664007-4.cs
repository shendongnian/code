    [HttpPost]
    public ActionResult Create(CreateVm model)
    {
      var e=new TimeStamp { ClockIn=model.ClockIn,Clockout=model.Clockout };
      e.UserId = 1; // Replace here current user id;
      db.TimeStamps.Add(e);
      db.SaveChanges();
      return RedirectToAction("Index");      
    }
