    public ActionResult create()
    {
      var vm = new CreateCustomerVM();
      vm.IntermediaryOptions = GetOptions();
      return View(vm);
    }
    private List<SelectListItem> GetOptions()
    {
        return new List<SelectListItem>
        {
            new SelectListItem {Value = "0", Text = "No"},
            new SelectListItem {Value = "1", Text = "Yes"}
        };
    }
