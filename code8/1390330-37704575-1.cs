    public class PasswordHasher : IPasswordHasher
    {
        // Private properties
        private readonly AdvancedEncryptionStandardProvider _provider;
        public PasswordHasher(AdvancedEncryptionStandardProvider provider)
        {
            this._provider = provider;
        }
        public string HashPassword(string password)
        {
            // Do no hashing
            return this._provider.Encrypt(password);
        }
        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            // Throw an error if any of our passwords are null
            ThrowIf.ArgumentIsNull(() => hashedPassword, () => providedPassword);
            // Just check if the two values are the same
            if (hashedPassword.Equals(this.HashPassword(providedPassword)))
                return PasswordVerificationResult.Success;
            // Fallback
            return PasswordVerificationResult.Failed;
        }
    }
