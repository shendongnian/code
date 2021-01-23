    public IActionResult Index()
    {
        var daysList =Enumerable.Range(1, 7)
           .Select(g => new SelectListItem {Value = g.ToString(), Text =g.ToString()}).ToList();
        return View(daysList);
    }
