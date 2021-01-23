    [AllowAnonymous]
            [HttpPost]
            public ActionResult SelectLanguage(LoginViewModel model)
            {
                switch (model.SelectedLanguage)
                {
                    case "French":
                        ChangeCulture("fr-Fr");
                        break;
                }
    
                return RedirectToAction("Index");
    
            }
