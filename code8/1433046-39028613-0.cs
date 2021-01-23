    public class CustomPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // Custom encrypted password
        }
    
        public PasswordVerificationResult VerifyHashedPassword(
            string hashedPassword, string providedPassword)
        {
            if (hashedPassword.Equals(providedPassword))
                return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }
    }
