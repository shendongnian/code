    // Remove Index, and rename PasswordInput to Index
    public ActionResult Index() 
    {
        FormInputs pss = new FormInputs();
    
        // pss.passWord = password;
    
        MyViewModel mvm = new MyViewModel { input = pss, isList = false };
    
        return View(mvm);
    }
    
    
    [HttpPost]
    public ActionResult Index(MyViewModel model)
    {
        var selected = model.inputCollection.Where(x => x.Checked).Select(x => x.Name);
        //ViewBag.Values = String.Join(", ", list);
        ViewBag.Values = selected;
    
        model.input = new FormInputs(); // <-- You need to instantiate FormInputs
        model.inputCollection = model.inputCollection;
        model.isList = true;
    
        return View( model);
    }
