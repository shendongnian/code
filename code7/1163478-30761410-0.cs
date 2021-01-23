         [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, model.FirstName));
                    var service = new GRCMemberService(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
                    service.CreateGRCMember(model.FirstName, model.LastName, model.Address1, model.Address2, model.City, model.County, model.Postcode, model.Telephone, model.DateOfBirth, model.Dietary, model.CompLicenceNo, model.SelectedLicenceTypeId, model.NOKFirstName, model.NOKLastName, model.NOKTelephone, model.RelationshipTypeId, model.OtherOrgsGRC, model.OtherClubEvents, model.OtherOrgsOutside, user.Id);
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }
