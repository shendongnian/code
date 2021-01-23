    public ActionResult Index()
    {
        var ModelVariables= new ModelVariables()
        {
            DropDownItems = Repository.DDFetchItems(),
            SelectedItems = new List<int>(){ 1, 3 } // to preselect the 1st and 3rd options
        };
        return View(model);
    }
