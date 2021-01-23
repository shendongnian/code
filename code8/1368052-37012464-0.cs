    public class ApplicationUser : IdentityUser
    {
        //This is the property that will match your column
        public DateTime CreationDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            
            return userIdentity;
        }
    }
