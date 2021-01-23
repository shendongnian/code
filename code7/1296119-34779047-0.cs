      public ActionResult Index()
      {
      	foreach (var r in db.Details.Where(emp => emp.DateExpired.HasValue && emp.DateExpired.Value == DateTime.Today))
      	{
      		r.Expire = true;
      	}
      	db.SaveChanges();
      	return View();
      }
