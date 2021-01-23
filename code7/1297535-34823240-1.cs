    public ActionResult People()
    {
       var peopleDictionary = db.People
                              .Select(x=> new {  Id = x.Id, Name= x.FirstName})
                              .ToDictionary(d => d.Id.ToString(), p => p);
       return Json(peopleDictionary, JsonRequestBehavior.AllowGet);
    }
