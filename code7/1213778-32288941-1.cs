    [HttpGet]
    public ActionResult Index()
        {
            var vm = new BookingViewModel();
            var citiesList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Oslo", Text = "Oslo" },
                new SelectListItem { Value = "Copenhagen", Text = "Copenhagen" },
                new SelectListItem { Value = "Stockholm", Text = "Stockholm" }
            };
            vm.Cities = citiesList;
            return View(vm);
        }
