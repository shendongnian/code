        //
		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterModel model)
		{
			DbEntities db = new DbEntities();
			AccountRole accountrole = db.AccountRoles.First(x => x.AccountRoleLabel=="USER");
			model.Role = accountrole;
		
			if (ModelState.IsValid)
			{
				// Tentative d'inscription de l'utilisateur
				try
				{
					WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Name = model.Name, AccountRoleRefId = model.Role.AccountRoleId}, false);
					WebSecurity.Login(model.UserName, model.Password);
					return RedirectToAction("Index", "Home");
				}
				catch (MembershipCreateUserException e)
				{
					ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
				}
			}
			// Si nous sommes arrivés là, quelque chose a échoué, réafficher le formulaire
			return View(model);
		}
