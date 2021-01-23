    [Authorize]
    public class PageController : Controller
    {
        IAuthorizationService _authorizationService;
        public PageController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public Delete(int pageId)
        {
            var page = pageRepo.GetPage(pageId);
            if (await authorizationService.AuthorizeAsync(User, page,  Operations.Delete))
            {
                return View(page);
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
