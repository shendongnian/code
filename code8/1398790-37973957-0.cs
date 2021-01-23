    public class CustomUserValidator<TUser> : IIdentityValidator<TUser>
        where TUser : class, Microsoft.AspNet.Identity.IUser
    {
        private static readonly Regex EmailRegex = new Regex(Consts.EmailRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //in my case EmailRegex = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$"; but you can use your own
        private readonly UserManager<TUser> _manager;
        public CustomUserValidator()
        {
        }
        public CustomUserValidator(UserManager<TUser> manager)
        {
            _manager = manager;
        }
        public async Task<IdentityResult> ValidateAsync(TUser item)
        {
            var errors = new List<string>();
            if (!EmailRegex.IsMatch(item.UserName))
                errors.Add("Bad email address");
            if (_manager != null)
            {
                var otherAccount = await _manager.FindByNameAsync(item.UserName);
                if (otherAccount != null && otherAccount.Id != item.Id)
                    errors.Add("Email already exists");
            }
            return errors.Any()
                ? IdentityResult.Failed(errors.ToArray())
                : IdentityResult.Success;
        }
    }
