    public ActionResult Index(ListPage currentPage, int? page, bool checkAnimals = false, bool checkFurniture= false, bool checkCars= false, bool checkHouses= false)
    {
        List<ListItem> filterResult = new List<ListItem>();
        ListResult allListResult = _searchService.GetPagesByPageType<>();
        ListResult carsResult = _searchService.GetPagesByPageType<Cars>();
        ListResult furnitureResult = _searchService.GetPagesByPageType<Furniture>();
        ListResult housesResult = _searchService.GetPagesByPageType<Houses >();
        ListResult animalsResult = _searchService.GetPagesByPageType<Animals>();
        if (checkAnimals)
            {
                filterResult = filterResult.Concat(animalsResult.Items).ToList();
            }
            if (checkFurniture)
            {
                filterResult = filterResult.Concat(furnitureResult .Items).ToList();
            }
            if (checkCars)
            {
                filterResult = filterResult.Concat(carsResult.Items).ToList();
            }
            if (checkHouses)
            {
                filterResult = filterResult.Concat(housesResult.Items).ToList();
            }
        var model = new ListPageViewModel(currentPage)
        {
            AllPages = allBaseEditorialPagesResult.Items,
            TotalMatching = allBaseEditorialPagesResult.TotalMatching,
            FilteredPages = filterResult,
            TotalFilteredMatching = filterResult.Count()
        };
        return View(model);
    }
