    [HttpPost]
    public ActionResult DoSomethingWithSelectedResults()
    {
        // Load initial model data here, in this case I had simply cached the results in
        // temp data in the previous action as suggested by Emeka Awagu.
        ResultsViewModel model = (ResultsViewModel)TempData["results"];
        // Call UpdateModel and let it do it's magic.
        UpdateModel(model);
        // ...
        return View(new DoSomethingWithSelectedResultsViewModel
        {
            SelectedResults = model.Results.Where(r => r.Selected).ToList(),
            SomeOtherProperty = "...",
            // ...
        });
    }
