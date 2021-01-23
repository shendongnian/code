        public ActionResult Index()
        {
            List<SelectListItem> LanguageOption = new List<SelectListItem>{
                new SelectListItem { Value = 1.ToString(), Text = "English" },
                new SelectListItem { Value = 2.ToString(), Text = "Arabic" },
                new SelectListItem { Value = 3.ToString(), Text = "French" }
            };
            //here you can set selected value
            model.SelectedLanguageId = 1;
            model.NoofSupportingLanguages = LanguageOption;
            return View(model);
        }
