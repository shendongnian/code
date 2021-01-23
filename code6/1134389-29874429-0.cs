    public ActionResult Testimonials()
    {
        getSearchResults("test");
        return View(result);
    }
