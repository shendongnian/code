    [HttpPost]
    public ActionResult Rent(RentMovieVm model)
    {
      var movieId = model.MovieId;
      var customerId = model.CustomreId;
      // to do  : Save this to your Rental Table
      // to do : Return something ( redirect to success page)
    }
