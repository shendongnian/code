    using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
        try
        {
            AppUserManager appUserManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser member = await appUserManager.FindByIdAsync(User.Identity.GetUserId());
            member.HasScheduledChanges = true;
            IdentityResult identityResult = appUserManager.Update(member);
            scope.Complete();
        }
        catch (Exception ex)
        {
            scope.Dispose();
            throw;
        }
    }
