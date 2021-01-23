    public ActionResult Edit(int userId)
    {
         // Get your user's information
         User user = userRepository.GetById(userId);
         UserViewModel model = new UserViewModel();
         model.Name = user.FirstName + " " + user.LastName;
         // This can be separated into a repository class of its own if you need to use colours in another action method
         model.Colours = new List<Colour>
         {
             new Colour { Id = 1, Name = "Blue" },
             new Colour { Id = 2, Name = "Green" },
             new Colour { Id = 3, Name = "Red" },
             new Colour { Id = 4, Name = "Yellow" }
         };
         return View(model);
    }
