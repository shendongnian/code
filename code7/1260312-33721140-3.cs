    // GET: AppForm
		public ActionResult Index() {
			
			ApplicationUser user = AppFormManager.GetCurrentUser();
			var model = new AppFormIndexViewModel();
			if (user != null) {
					model.PercentComplete = user.AppForm.PercentComplete;
					model.NextPage = "Page" + user.AppForm.LastPageCompleted + 1;
					model.Status = user.AppForm.Status;
			}
			return View(model);
		}
