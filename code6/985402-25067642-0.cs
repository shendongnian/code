    void Main()
    {
        var passwords = new string[] {"password", "passw0rd", "passw0rd!", "123456", "!#@$"};
    
        foreach (var pw in passwords)
        {
            var checker = new PasswordChecker(pw);
            var isValid = checker.IsValid;
    
            Console.WriteLine("Password {0} is {1}valid.", pw, isValid ? "" : "in");
    
            if (!isValid)
            {
                Console.WriteLine("    Has alpha?  {0}", checker.HasAlpha ? "Yes." : "NO!");
                Console.WriteLine("    Has number?  {0}", checker.HasNumber ? "Yes." : "NO!");
                Console.WriteLine("    Has special?  {0}", checker.HasSpecial ? "Yes." : "NO!");
                Console.WriteLine("    Has length?  {0}", checker.HasLength ? "Yes." : "NO!");
            }
        }
    }
    
    public class PasswordChecker
    {
        public const int MINIMUM_LENGTH = 3;
        private string _password;
    
        public PasswordChecker(string password)
        {
            _password = password;
        }
    
        public bool HasAlpha
        {
            get
            {
                return Regex.Match(_password, "(?=.*?[a-zA-Z])").Success;
            }
        }
    
        public bool HasNumber
        {
            get
            {
                return Regex.Match(_password, "(?=.*?[0-9])").Success;
            }
        }
    
        public bool HasSpecial
        {
            get
            {
                return Regex.Match(_password, "(?=.*?[!@#$]+)").Success;
            }
        }
    
        public bool HasLength
        {
            get
            {
                return _password.Length >= MINIMUM_LENGTH;
            }
        }
    
        public bool IsValid
        {
            get
            {
                return HasLength && HasAlpha && HasNumber && HasSpecial;
            }
        }
    }
