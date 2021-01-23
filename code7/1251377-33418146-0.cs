    public HomeController: Controller
    {
        public ActionResult Administration()
        {
            // Determine the user's role. 
            // "GetRole()" does not really exist on the controller - use your own method.
            string role = GetRole();
            if (role == "Billing Guy")
                return View("AdministrationBillingGuy")
            else if (role == "SalesGuy")
                return View("AdministrationSalesGuy")
            else
                return View();
            // etc.
        }
    }
