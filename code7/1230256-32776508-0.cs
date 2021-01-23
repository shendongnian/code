     public class HashGenerator : IHashGenerator
        {
            public string GenerateHash(string input, string salt)
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
                var hashAlgoritm = System.Security.Cryptography.MD5.Create();
                bytes = hashAlgoritm.ComputeHash(bytes);
                return Convert.ToBase64String(bytes);
            }
    
            public string CreateSalt()
            {
                var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
                var buff = new byte[25];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);
            }
        }
