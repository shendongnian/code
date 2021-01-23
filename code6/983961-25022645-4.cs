    public ActionResult Index()
        {
            var model = new ViewModel
                {
                    Links = new List<string>
                        {
                            "Hello",
                            "Goodbye",
                            "Seeya"
                        }
                };
            return View(model);
        }
