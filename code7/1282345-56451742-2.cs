    // GET
    public ActionResult Create()
    {
      var dataObjectVM = GetNewMyDataObjectVM();
      return View(dataObjectVM); // I use T4MVC, don't you?
    }
    
    private MyDataObjectVM GetNewMyDataObjectVM(MyDataObjectVM model = null)
    {
      return new MyDataObjectVM
      {
        int id = model?.Id ?? 0,
        string StrValue = model?.StrValue ?? "", 
        var strValues = new List<SelectListItem> 
          { 
            new SelectListItem {Text = "Select", Value = ""},
            new SelectListITem {Text = "Item1", Value = "Item1"},
            new SelectListItem {Text = "Item2", Value = "Item2"}
          };
      };
    }
    
    // POST
    public ActionResult Create(FormCollection formValues)
    {
      var dataObject = new MyDataObject();
    
      try
      {
        UpdateModel(dataObject, formValues);
        AddObjectToObjectStore(dataObject);
        return RedirectToAction(Actions.Index);
      }
      catch (Exception ex)
      {
        // fill in the drop-down list for the view model
        var dataObjectVM = GetNewMyDataObjectVM();
        ModelState.AddModelError("", ex.Message);
        return View(dataObjectVM);
      )
    }
