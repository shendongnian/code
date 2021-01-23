        public ActionResult Index()
        {
           var checkBoxViewModel = new IList<CheckBoxViewModel>();
           foreach(var item in myQueryResultModel)
           {
             checkBoxViewModel.add(new CheckBoxViewModel{
             Name = item.Name
             Description = item.Description
             });
           }
           return View(checkBoxViewModel);
        }
