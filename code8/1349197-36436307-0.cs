    public ActionResult GeneralSearch()
    {
        return View();
    }
    [HttpPost]
    public ActionResult GeneralSearch(string searchString)
    {
        return View("SearchResult", viewModel);
    }
