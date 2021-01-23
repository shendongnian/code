    [HttpGet]
    public ActionResult Index(SearchFormViewModel search)
    {
        // If it was a search submit, CounterKey which is not nullable should contains something
 
        if (!String.IsNullOrEmpty(search.CounterKey)) { 
           return ActualSearch(search) ; 
        }
         
        // Display search page
        HomeIndexViewModel model = new HomeIndexViewModel()
        {
            SearchForm = new SearchFormViewModel()
            {
                GeoCounterDefinitions = geocounterservice.getAllDefinitions()
               .Select(x => new SelectListItem()
                {
                    Text = x.CounterKey + " " + x.FriendlyDesc,
                    Value = x.CounterKey.ToString()
                })
            }
        };
        return View(model);
    }
    private ActionResult ActualSearch(SearchFormViewModel search)
    {
        if (!ModelState.IsValid)
        {
            return View(new HomeIndexViewModel() {
                SearchForm = new SearchFormViewModel()
                {
                    CounterKey = search.CounterKey,
                    StartDate = search.StartDate,
                    EndDate = search.EndDate,
                    GeoCounterDefinitions = geocounterservice.getAllDefinitions()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.CounterKey + " " + x.FriendlyDesc,
                        Value = x.CounterKey.ToString()
                    })
                }
            });
        }
        return RedirectToAction("Search");
    }
