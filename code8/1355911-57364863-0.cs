    @using Microsoft.AspNetCore.Identity
    @inject SignInManager<IdentityUser> SignInManager
    @inject UserManager<IdentityUser> UserManager
    
     @if (SignInManager.IsSignedIn(User))
        {
            <p>Hello @User.Identity.Name!</p>
        }
        else
        {
            <p>You're not signed in!</p>
        }
