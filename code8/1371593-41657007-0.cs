    public ActionResult UserHome()
    {
    	if (Session["UserLoginID"] != null)
    	{
    		using (ToDoDBEntities db = new ToDoDBEntities())
    		{
                // Include fetches the data behind navigation properties
    			return View(db.MyListItems.Include(x => x.UserProfiles).ToList());
    		}
    	}
    	else
    	{
    		return RedirectToAction("LogIn");
    	}
    }
