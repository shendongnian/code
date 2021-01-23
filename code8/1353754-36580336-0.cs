        public ActionResult Order()
        {
            var viewModel = new ViewOrderViewModel();
            // Load data into each property
            viewModel.OrderId = 123; // etc..
            
            // Return it to the view. Asp.net knows to return
            // it to the Order.cshtml view because the view
            // and the controller action share the same name.
            return View(viewModel);
        }
