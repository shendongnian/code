    [Authorize(Roles = "Managers")]
            public ActionResult CompanySecrets()
            {
                return View();
            }
    
            [Authorize(Users="redmond\\swalther")]
            public ActionResult StephenSecrets()
            {
                return View();
            }
