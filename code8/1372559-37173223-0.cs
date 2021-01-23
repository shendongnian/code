    [HttpPost]
    public IActionResult Create(TeamVM vm)
    {
         FormFileExtensions.SaveAs(vm.UploadedLogo, "C:\pathTofile");
         return View();
    }
