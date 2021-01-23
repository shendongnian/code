    public ActionResult AddComment(int id = 0)
    {
        var model = new comment(){ SPID = id };
        return View(model );
    }
