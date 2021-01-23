    public class CustomUserValidator<TUser> : UserValidator<TUser, int>
        where TUser : ApplicationUser
    {
        public bool RequireUniqueAlias { get; set; }
        public CustomUserValidator(UserManager<TUser, int> manager) : base(manager)
        {
            this.Manager = manager;
        }
    
        private UserManager<TUser, int> Manager { get; set; }
    
        public override async Task<IdentityResult> ValidateAsync(TUser item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var errors = new List<string>();
            await ValidateUserName(item, errors);
            if (RequireUniqueEmail)
            {
                await ValidateEmail(item, errors);
            }
            if (RequireUniqueAlias)
            {
                await ValidateAlias(item, errors);
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }
    
        private async Task ValidateUserName(TUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.PropertyTooShort, "Name"));
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
            {
                // If any characters are not letters or digits, its an illegal user name
                errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.InvalidUserName, user.UserName));
            }
            else
            {
                var owner = await Manager.FindByNameAsync(user.UserName);
                if (owner != null && !EqualityComparer<int>.Default.Equals(owner.Id, user.Id))
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.DuplicateName, user.UserName));
                }
            }
        }
    
        // make sure email is not empty, valid, and unique
        private async Task ValidateEmail(TUser user, List<string> errors)
        {
            if (!user.Email.IsNullOrWhiteSpace())
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.PropertyTooShort, "Email"));
                    return;
                }
                try
                {
                    var m = new MailAddress(user.Email);
                }
                catch (FormatException)
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.InvalidEmail, user.Email));
                    return;
                }
            }
            var owner = await Manager.FindByEmailAsync(user.Email);
            if (owner != null && !EqualityComparer<int>.Default.Equals(owner.Id, user.Id))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.DuplicateEmail, user.Email));
            }
        }
    
        private async Task ValidateAlias(TUser user, List<string> errors)
        {
            if (!user.Alias.IsNullOrWhiteSpace())
            {
                if (string.IsNullOrWhiteSpace(user.Alias))
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.PropertyTooShort, "Alias"));
                    return;
                }
            }
            var owner = Manager.Users.FirstOrDefault(x => x.Alias == user.Alias);
            if (owner != null && !EqualityComparer<int>.Default.Equals(owner.Id, user.Id))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, CustomResources.DuplicateAlias, user.Alias));
            }
        }
    }
