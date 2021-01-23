    public static String GetSha2Thumbprint(X509Certificate2 cert)
            {
                Byte[] hashBytes;
                using (var hasher = new SHA256Managed())
                {
                    hashBytes = hasher.ComputeHash(cert.RawData);
                }
                string result = BitConverter.ToString(hashBytes)
                    // this will remove all the dashes in between each two haracters
                .Replace("-", string.Empty).ToLower();         
                return result;
            }
    After getting the Hashbytes , you have to do the bit convertion.
