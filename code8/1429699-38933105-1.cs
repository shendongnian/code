    [AllowAnonymous]
            public ActionResult Register()
            {
                var _context = new ApplicationDbContext();
                var roles = _context.Roles.ToList();
                var viewModel = new RegisterViewModel
                {
                    RolesList = roles
                };
                return View(viewModel);           
            }
