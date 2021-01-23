     [AllowAnonymous]
            [HttpPost]
            public ActionResult SelectLanguage(LoginViewModel model)
            {
                switch (model.SelectedLanguage)
                {
                    case "French":
                        LanguageStrings.Culture = new CultureInfo("fr-fr");
                        break;
                }
        
                return RedirectToAction("Index");
                
            }
        
