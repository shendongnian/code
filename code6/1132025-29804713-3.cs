    public ActionResult DisplayUsers(string sortOrder, string searchString)
	{
		ViewBag.NameSortParm1 = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
		ViewBag.NameSortParm2 = String.IsNullOrEmpty(sortOrder) ? "role_desc" : "";
		ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
		
		var users = from a in db.app_user
					select a;
		
		switch (sortOrder)
		{
			case "name_desc":
				users = users.OrderByDescending(a => a.username);
				break;
			case "role_desc":
				users = users.OrderBy(a => a.user_role);
				break;
			case "date_desc":
				users = users.OrderBy(a => a.date_of_register);
				break;
			default:
				users = users.OrderBy(a => a.username);
				break;
		}
 
		return this.View(users.ToList());
		// return View(db.app_user.ToList());
	} 
