    class UsersController
    {
        private readonly IMembershipRepository Repository;
    
        public UsersController(IMembershipRepository repository)
        {
            Repository = repository;
        }
    
        public ActionResult Index()
        {
            Guid myId = Guid.Parse(User.Identity.GetUserId());
            var profiles = Repository.GetUsersForManager(myId);
            return View(profiles);
        }
    }
