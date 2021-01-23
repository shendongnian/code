    public IActionResult Create()
    {
        var vm = new SchoolViewModel();
        vm.Districts = _context.Districts.Select(d => new
        {
    	    Text = d.District,
    	    Value = d.DistrictId.ToString()
        };
        //repeat for others...
        return View(vm);
    }
