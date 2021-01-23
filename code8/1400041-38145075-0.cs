            public ActionResult Contact()
        {
            Contact homeViewModel = new Contact();
            homeViewModel.subject = new List<Subject>();
            homeViewModel.subject.Add(new Subject { Id = 1, subject1 = "General Customer Service" });
            homeViewModel.subject.Add(new Subject { Id = 2, subject1 = "Suggestions" });
            homeViewModel.subject.Add(new Subject { Id = 3, subject1 = "Product Support" });
            homeViewModel.Selectedid = 1; //this sets the default value for your dropdown
            
            return View(homeViewModel);
        }
