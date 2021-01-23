    public ActionResult Create()
    {
      return View(new CreateOrEditVM());
    }
    public ActionResult Edit(int id)
    {
      var vm = new CreateOrEditVM()'
      var slide = yourService.GetSlideFromId(id);
      vm.SlideId=slide.Id;
      vm.SlideName = slide.Name;
      return View(vm);
    }
    
    [HttpPost]
    public ActionResult Create(CreateOrEditVM model)
    {
       if(model.SlideId==0)
       {
          // coming from Create form 
       }
       else
       {
         //Coming from Edit form
       }
       // to do :Save and redirect
    }
