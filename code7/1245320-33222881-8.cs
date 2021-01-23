    [HttpPost]
    public ActionResult LoadRelease(string Project, string Release)
    {
        // search
        return PartialView("_TableBody", results);
    }
