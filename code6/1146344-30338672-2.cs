    using Thinktecture.IdentityServer.Core.Extensions;
    using Thinktecture.IdentityServer.Core.Models;
    
    ...
    
    AuthenticatedLogin login = new AuthenticatedLogin()
        {   
            IdentityProvider = Thinktecture.IdentityServer.Core.Constants.BuiltInIdentityProvider,
            Subject = userId,
            Name = AuthObjects.AuthUserService.GetDisplayNameForAccount(userId)  
        };
    Request.GetOwinContext().Environment.IssueLoginCookie(login);
    
    HttpCookie cookie = Request.Cookies["signin"];
    if (cookie != null)
    {
        SignInMessage message = Request.GetOwinContext().Environment.GetSignInMessage(cookie.Value);
        return Redirect(message.ReturnUrl);
    }
    else
    
    ...
