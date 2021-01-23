        // GET: /Account/AccessDenied
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied(string returnUrl = null)
        {
            // workaround
            if (Request.Cookies["Identity.External"] != null)
            {
                return RedirectToAction(nameof(ExternalLoginCallback), returnUrl);
            }
            return RedirectToAction(nameof(Login));
        }
