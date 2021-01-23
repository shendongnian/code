    public class Security
    {
        public static bool ValidatePassword(string password)
        {
            string hashValue = HashPassword(password);
            if (hashValue == ConfigurationManager.AppSettings["password"])
            {
                return true;
            }
            return false;
            
        }
        private static string HashPassword(string passwordToHash)
        {
            HashAlgorithm hash = new SHA256Managed();
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(passwordToHash);
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            //in this string you got the encrypted password
            return Convert.ToBase64String(hashBytes);
        }
    }
