    [HttpPost]
    public ActionResult Create(CreateVm model)
    {
      var e=new TimeStamp { UserId=model.SelectedUserId, 
                            ClockIn=model.ClockIn, Clockout=model.Clockout };
      db.TimeStamps.Add(e);
      db.SaveChanges();
      return RedirectToAction("Index");
      
    }
