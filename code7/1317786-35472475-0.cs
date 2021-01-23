    public ActionResult Page(int id) //instead of page use id here
    {
        PostModel pm = new PostModel(id);
        return View(pm);
    }
