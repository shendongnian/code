    [HttpPost]
    public ActionResult Edit(ClassA model){
    
    
    // HEre you will see model.ClassB list
    // you can then save them one by one
    
    foreach(var item in Model.classB){
    
    save
    }
    return View(model);
    }
