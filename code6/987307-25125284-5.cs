	[HttpPost]
	public ActionResult Create(Assignment assignment)
	{
		if (ModelState.IsValid)
		{
			if(Request.Files.Count > 0)
			{
				HttpPostedFileBase assignmentFile = Request.Files[0];
				if (file.ContentLength > 0) 
				{
					var fileName = Path.GetFileName(file.FileName);
					assignment.FileLocation = Path.Combine(
						Server.MapPath("~/App_Data/uploads"), fileName);
					file.SaveAs(assignment.FileLocation);
				}
				db.Assignments.Add(assignment);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
		}
		return View(assignment);
	}
