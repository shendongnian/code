    public IActionResult Index()
    {
        var vm = new CreateUserVm
        {
            Roles = new List<RoleVm>
            {
                new RoleVm {Id = 1, RoleName = "Admin"},
                new RoleVm {Id = 2, RoleName = "Editor"},
                new RoleVm {Id = 3, RoleName = "Reader"}
            }
        };
        return View(vm);
    }
