    public ActionResult Create()
    {
      var vm=new CreateViewModel();
      //Hard coded for demo. You may replace with data form db.
      vm.Widgets = new List<SelectListItem>
                {
                    new SelectListItem {Value = "1", Text = "Weather"},
                    new SelectListItem {Value = "2", Text = "Messages"}
                };
     return View(vm);
    }
