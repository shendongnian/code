    public ActionResult Rent()
    {  
      var vm = new RentMovieVm();
      vm.Customers= dbContext.Customers.Select(s=> new SelectListItem { 
                                                 Value =s.CustomerId.ToString(),
                                                 Text= s.FirstName+" "+ s.LastName }).ToList();
      vm.Movies= dbContext.Movies.Select(x=> new SelectListItem { 
                                                   Value =x.MovieId.ToString(),
                                                   Text= x.Title }).ToList();
      return View(vm);
    }
