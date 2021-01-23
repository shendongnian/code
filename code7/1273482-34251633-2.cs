    public class IdentityUser : 
      IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUser, IUser<string>
    {
      /// <summary>
      /// Constructor which creates a new Guid for the Id
      /// </summary>
      public IdentityUser()
      {
        this.Id = Guid.NewGuid().ToString();
      }
