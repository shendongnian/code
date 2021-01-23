        public ActionResult AddNonPersistedClaim()
        {
            var identity = (ClaimsIdentity)ClaimsPrincipal.Current.Identity;
            identity.AddClaim(new Claim("Hello", "World"));
            return RedirectToAction("SomeAction");
        }
