     var vm = new DepartmentViewModel();
     vm.DepartmentSelectList = new DepartmentService().GetAll().Select(c => new SelectListItem
            {
                Text = c.DepartmentName,
                Value = c.Id.ToString()
            }).ToList();
