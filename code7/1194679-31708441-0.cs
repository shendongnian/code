    [HttpPost]
    public ActionResult ProcessChild1(Child1 model)
    {
        if (Model.IsValid)
        {
            if (model.Id == 0)
            {
                //create MainModel
                var mainModel = new MainModel();
                //attach new Child1
                mainModel.Child1 = new Child1();
                //save changes
                context.MainModels.Add(mainModel);
                context.SaveChanges();
                model.MainModel = mainModel;
            }
            else
            { 
                //find Child1 by ID
                var Child1 = context.Child1.Find(model.Id);
                //update Child1
                //save changes
                model.MainModel = Child1.MainModel;
            }
            return View("Child2View", new Child2() { MainModel = model.MainModel }); 
        }
        return View("Child1View", model);
    }
   
