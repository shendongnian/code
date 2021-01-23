    public static class RegexExtensions
    {
        private readonly Regex UserNameAlreadyExists = new Regex("(the user .* already exists)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static bool IsUserNameAlreadyExists(this string inputValue)
        {
            return UserNameAlreadyExists.IsMatch(inputValue);
        }
    }
