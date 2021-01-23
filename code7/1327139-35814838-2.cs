    public class UserProfileViewComponent : ViewComponent
        {
        readonly UserManager<ApplicationUser> userManager;
        public UserProfileViewComponent(UserManager<ApplicationUser> userManager)
            {
            Contract.Requires(userManager != null);
            this.userManager = userManager;
            }
        public IViewComponentResult Invoke([CanBeNull] ClaimsPrincipal user)
            {
            return InvokeAsync(user).WaitForResult();
            }
        public async Task<IViewComponentResult> InvokeAsync([CanBeNull] ClaimsPrincipal user)
            {
            if (user == null || !user.IsSignedIn())
                return View(anonymousUser);
            var userId = user.GetUserId();
            if (string.IsNullOrWhiteSpace(userId))
                return View(anonymousUser);
            try
                {
                var appUser = await userManager.FindByIdAsync(userId);
                return View(appUser ?? anonymousUser);
                }
            catch (Exception) {
            return View(anonymousUser);
            }
            }
        static readonly ApplicationUser anonymousUser = new ApplicationUser
            {
            Email = string.Empty,
            Id = "anonymous",
            PhoneNumber = "n/a"
            };
        }
