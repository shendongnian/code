    public static class AppFormManager {
		public static ApplicationUser GetCurrentUser() {
			ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
			if (user != null) {
				AppForm form = new AppForm();
				ApplicationDbContext db = new ApplicationDbContext();
				AppForm ap = db.AppForms.Where(af => af.Id == user.AppFormId).Include("Answers").Include("Documents").SingleOrDefault();
				if (ap == null) {
					var AppForm = new AppForm { PercentComplete = 0, Reviewed = false, Status = "Incomplete", SignedOff = false, Completed = false, LastPageCompleted = 0 };
					user.AppForm = AppForm;
				} else {
					user.AppForm = ap;
				}
				return user;
			}
			return null;
		}
		public static bool SaveCurrentUser() {
			ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
			if (user == null) { return false; }
			var uManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
			uManager.UpdateAsync(user);
			return true;
		}
	}
