    switch (result)
    {
        case SignInStatus.Success:
        
            var AccountLog = new AccountLog()
            {
    
                IPv4 = GetExternalIP(),
                LoginDate = DateTime.Now,
                UserId = user.Id,
            };
    
            user.AccountLogs.Add(AccountLog);
        
            // get the entity framework context.
            var dbContext = Context.GetOwinContext().Get<ApplicationDbContext>();
            // save the changes to objects tracked by this context
            dbContext.SaveChanges();
    
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        
            break;
    case SignInStatus.LockedOut:
     // removed for brevity.
        break;
          
    }
