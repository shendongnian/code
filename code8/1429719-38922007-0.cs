    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    // change to async
    public async Task<ActionResult> Register(AccountViewModel model)
    {
    	if (ModelState.IsValid)
    	{
    		try
    		{
    			var service = BusinessServiceFacade.GetAccountService(RavenMasterSession);
    			
    			// broken apart so you can see the await call
    			await service.Create(model.ToModel(), model.SubscriptionPlanId);
    			
    			return Redirect(string.Format("http://{0}.localhost:6257/Admin/GettingStarted",model.Name));
    		}
    		catch(AccountTakenException)
    		{
    			ModelState.AddModelError("", "Account name already taken");
    		}
    		catch (CustomException e)
    		{
    			ModelState.AddModelError("", "Error:" + e);
    		}
    	}
    	return View(model);
    }
