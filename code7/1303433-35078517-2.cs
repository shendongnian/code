    public class MyLegacyUserClaimsStore : IUserClaimStore<MyLegacyUser>
    {
        // Here I simply returned the username of the user parameter I recieved as input
        public Task<string> GetUserIdAsync(MasterUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() => user.UserName, cancellationToken);
        }
    }
    // Here I simply returned the username of the user parameter I recieved as input
    public Task<string> GetUserNameAsync(MasterUser user, CancellationToken cancellationToken)
    {
        return Task.Run(() => user.UserName, cancellationToken);
    }
    public Task<MasterUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        // This is my manager class to read my user for the userId
        // Add your own code to read the user for the set Id here
        return Task.Run(() => new MyLegacyUserUserManager().ReadForEmailAddress(userId, 0, true, true), cancellationToken);
    }
     public Task<MasterUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
     {
         // This is my manager class to read my user for the normalizedUserName
        // Add your own code to read the user for the set normalizedUserName here
         return Task.Run(() => new MyLegacyUserManager().ReadForEmailAddress(normalizedUserName, 0, true, true), cancellationToken);
     }
    // If you want to make use of Claims make sure that you map them here
    // If you do not use claims, consider implementing one of the other IUserStore interfaces 
    //such as the IUserLoginStore so that you do not have to implement the GetClaimsAsync method
    public async Task<IList<Claim>> GetClaimsAsync(MasterUser user, CancellationToken cancellationToken)
    {
        var claims = new List<Claim>();
        foreach (var claim in user.Claims)
        {
            claims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
        }
        return claims;
    }
