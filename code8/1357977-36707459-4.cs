        public ActionResult Index()
        {
           var checkBoxViewModel = new IList<CheckBoxViewModel>();
           foreach(var item in myListOfStrings)
           {
             checkBoxViewModel.add(new CheckBoxViewModel{
             Name = item,
             Checked = false
             });
           }
           return View(checkBoxViewModel);
        }
