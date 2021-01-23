    public static string GetSignature(string base64Parameters, string base64tranEncryptKey)
            {
                using (var sha = new HMACSHA256(Convert.FromBase64String(base64tranEncryptKey)))
                {
                    var hash = sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(base64Parameters));
    
                    return Convert.ToBase64String(hash);
                }
            }
