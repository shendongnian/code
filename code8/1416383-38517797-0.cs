        IUserRepository _userRepository;
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            if (!_userRepository.ValidateLogin(userName, password))
            {
                ViewBag.ErrorMessage = "Invalid Login";
                return View();
            }
            await HttpContext.Authentication.SignInAsync("Cookie", _userRepository.Get(userName),
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });
            return RedirectToLocal(returnUrl);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return RedirectToAction("Index", "Home");
        }
