    [HttpGet]
    public ActionResult Index(SearchFormViewModel search)
    {
        if (search.IsSubmit) { 
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
