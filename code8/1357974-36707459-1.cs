        public ActionResult Index()
        {
           var checkBoxViewModel = new IList<CheckBoxViewModel>();
           foreach(var item in myListOfStrnigs)
           {
             checkBoxViewModel.add(new CheckBoxViewModel{
             Name = item,
             Checked = false
             });
           }
           return View(checkBoxViewModel);
        }
