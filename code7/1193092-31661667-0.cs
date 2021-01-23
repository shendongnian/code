    var permData = db.LabPermissions.Where(x => x.AccessLevel == 1).ToList();
    var vm = new ViewModel();
 
    var list = new List<SelectListItem>
            {
                new SelectListItem{ Value = "-1", Text = "Select One", Selected = true},
                new SelectListItem{ Value = "0",Text = "No"},
                new SelectListItem{ Value = "1",Text = "Yes"}
            };
    vm.DropDownData = list;
    vm.DataFromController = permData;
    return View(vm);
