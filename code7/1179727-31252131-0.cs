    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int _maxLength { get; set; }
        public CustomPasswordValidator(int maxLength)
        {
            _maxLength = maxLength;                
        }                   
        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Length > _maxLength)
            {
                return Task.FromResult(IdentityResult.Failed(String.Format("Password length can't exceed {0}", _maxLength)));
            }
            // TODO: Other business rules for password validation
            return Task.FromResult(IdentityResult.Success);
        }
    }
