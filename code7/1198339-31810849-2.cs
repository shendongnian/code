	public ActionResult Review() {
		var reviews = reviewRepo.GetAllReviews();
		var models = reviews.Select(s => new AdminReviewViewModel() {
			ClientID = s.ClientID,
			ReviewID = s.ReviewID,
			ReviewName = s.ReviewName,
			ReviewPeriodID = s.ReviewPeriodID,
			ReviewPeriodName = s.ReviewPeriod,
			Clients = clientRepo.Clients
		});
		return View(models);
	}
