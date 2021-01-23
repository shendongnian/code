    public ActionResult  Edit(int? id)
    {
      var vm = new NewsViewModel();
    
      vm.AllCategories = GetCategories();
      return View(vm);
    }
    private IEnumerable<SelectListItem> GetCategories()
    {
       return db.Categories
                .Select(s=>new SelectListItem { Value=s.Id.ToString(), 
                                                Text=s.Name).ToList();
    }
