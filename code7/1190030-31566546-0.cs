        [AllowAnonymous]
        public ActionResult Impersonate([Bind(Prefix = "id")]string email)
        {
            Impersonalisator.ImpersonateByEMail(email, Request);
            return RedirectToRoute("Default", new { action = string.Empty, controller = string.Empty });
        }
