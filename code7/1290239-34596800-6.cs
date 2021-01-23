    public ActionResult Index()
    {
        var search = new SearchVm
        {
            Filters = new List<SearchViewModel>
            {
                new SearchViewModel {Property = new Property {SqlColumn = "Name"}},
                new SearchViewModel {Property = new Property {SqlColumn = "Age"}},
                new SearchViewModel {Property = new Property {SqlColumn = "Location"}}
            }
        };
       //Convert the Enums to a List of SelectListItem 
       search.Operators= Enum.GetValues(typeof(SearchOperator)).Cast<SearchOperator>()
            .Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
       return View(search);
    }
