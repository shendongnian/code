    public ActionResult Index()
    {
      var vm = new CreateIssue();
      //Hard coded for demo. You may replace with values coming from db table.
      vm.Statuses = new List<SelectListItem> {
         new SelectListItem { Value="1", Text="Ready"},
         new SelectListItem { Value="2", Text="Done"},
         new SelectListItem { Value="3", Text="Building"},
         new SelectListItem { Value="4", Text="Error"},
      };
      //For preselecting items, set it here
      vm.SelectedStates=new int[] { 2,3};
      return View(vm);
    }
