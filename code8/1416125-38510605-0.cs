     [HttpPost]
     [ValidateInput(false)]
     public ActionResult Edit(NewsViewModel model,FormCollection col)
     {
        if (!ModelState.IsValid)
        {   
           var selected=  model.SelectedCategoriesIds;
           model = (NewsViewModel)Session["model"];
           model.SelectedCategoriesIds =selected;
           return View(model);
        } 
        //save and return something**strong text**
    }
