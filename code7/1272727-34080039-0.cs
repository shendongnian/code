        /***
        *** Added async and Task<ActionResult>
        ****/
        public async Task<ActionResult> Signin(User user)
        {
            //no token needed - we are requesting one
            // added await and remove .Result()
            Token token =  await _authenticationService.Authenticate(user, ApiUrls.Signin);
            return RedirectToAction("Index", "Dashboard", token.user);
        }
