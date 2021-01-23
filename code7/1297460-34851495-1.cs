    public IActionResult Create()
    {
      SchoolVM model = new SchoolVM
      {
        DistrictList = new SelectList(_context.Districts, "DistrictId", "District"),
        .....
      };
      return View(model);
    }
