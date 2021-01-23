     public ActionResult Index()
        {
            var sampleList = new List<string>()
            {
                "Amir",
                "Reza",
                "Kashan",
                "Niyasar",
                "Tehran"
            };
            return View(sampleList);
        }
