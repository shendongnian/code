       public IActionResult Index(HttpPostedFileBase file, string fileType, int fileSize)
        {
            ViewBag.Environments = _configHelper.GetEnvironments();
            var model = new HomeViewModel { Environment = "DEV" };
            return View(model);
        }
