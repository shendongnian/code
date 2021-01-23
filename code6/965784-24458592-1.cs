    public ActionResult Search(string searchString)
    {
        if(!string.IsNullOrEmpty(Request["searchString"]))
        { 
            return RedirectToAction("Search", new { searchString });
        }
        /* Do the rest of your processing here */
    }
