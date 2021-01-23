        using Compat = Microsoft.AspNet.Identity.CoreCompat;
        // update to use the compatibility class
        public class ApplicationDbContext : Compat.IdentityDbContext<ApplicationUser>
        // change all instances, such as this
        Compat.IdentityUser user = await _repo.FindUser(context.UserName, context.Password);  
