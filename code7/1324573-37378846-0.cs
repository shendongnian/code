    public class MyUserManager:UserManager<MinervaUser> 
    {
    ...
        public override bool SupportsUserSecurityStamp
        {
            get
            {
                return true;
            }
        }
        public override async Task<string> GetSecurityStampAsync(MinervaUser user)
        {
            // Todo: Implement something useful here!
            return "Token";
        }
        public override async Task<IdentityResult> UpdateSecurityStampAsync(MinervaUser user)
        {
            // Todo: Implement something useful here!
            return IdentityResult.Success;
        }
