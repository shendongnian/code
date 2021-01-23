    public class AdminReviewViewModel
    {
      public int ClientID { get; set; }
      public int ReviewID {get; set;}
      public string ReviewName { get; set; }
      public int? ReviewPeriodID { get; set; }
      public string ReviewPeriodName { get; set; }
    }
    public class AdminReviewListViewModel
    {
      public IEnumerable<Review> Reviews { get; set; } // Don't know what this is for, but leaving it.
      public IQueryable Clients { get; set; }
      public IQueryable<AdminReviewViewModel> ReviewList { get; set; }
    }
    public ActionResult Review()
    {
      AdminReviewListViewModel model = new AdminReviewListViewModel();
      model.Clients = clientRepo.Clients;
      var reviews = reviewRepo.GetAllReviews();
      model.ReviewList = reviews.Select(s => new AdminReviewViewModel() {
        ClientID = s.ClientID,
        ReviewID = s.ReviewID,
        ReviewName = s.ReviewName,
        ReviewPeriodID = s.ReviewPeriodID,
        ReviewPeriodName = s.ReviewPeriod,
        });
      return View(model);
    }
