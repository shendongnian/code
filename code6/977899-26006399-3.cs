        public ActionResult Index()
        {
            using (var uow = new UnitOfWork<SkipstoneContext>())
            {
                var userId = User.Identity.GetUserId();
                var service = new PageService(uow, this.CompanyId);
                var userService = new UserService(uow, this.CompanyId);
                var user = userService.Get(userId);
                var fileName = service.View(Request.Url, user);
                if (!fileName.StartsWith(@"/") && !fileName.StartsWith("~/"))
                    return View(fileName); // Show the page
                else
                    return Redirect(fileName); // Redirect to our page
            }
        }
