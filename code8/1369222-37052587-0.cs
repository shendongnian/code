     public ActionResult Index()
     {
        var result =db.Hospitals.Include("UserHospitals").where(x=> x.UserHospitals.Any(x=>x.Id== userId)).ToList();
        return View(result);
     }
