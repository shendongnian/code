    public ActionResult AddJob(string userCode)
    {
        var vm = new AddJobToUserVm {UserCode = client};
        vm.JobsNotAddedYet = new List<SelectListItem>
        {
            new SelectListItem {Value = "JobCode1", Text = "Job 1"},
            new SelectListItem {Value = "JobCode2", Text = "Job 2"}
        };
        vm.JobsOfUser = new List<string>() {"Job 25", " Job 26"};
        return View(vm);
    }
