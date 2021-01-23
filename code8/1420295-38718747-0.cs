    public static string Encrypt(string data)
        {
            try
            {
                var path = @"certificate.pfx";
                var password = "test";
                var collection = new X509Certificate2Collection();
                collection.Import(path, password, X509KeyStorageFlags.PersistKeySet);
                var certificate = collection[0];
                var publicKey = certificate.PublicKey.Key as RSACryptoServiceProvider;
                var bytesData = Convert.FromBase64String(data);
                var encryptedData = publicKey.Encrypt(bytesData, false);
                var cypherText = Convert.ToBase64String(encryptedData);
                return cypherText;
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
		public static string Decrypt(string data)
        {
            try
            {
                var path = @"certificate.pfx";
                var password = "test";
                var collection = new X509Certificate2Collection();
                collection.Import(path, password, X509KeyStorageFlags.PersistKeySet);
                var certificate = collection[0];
                var privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
                var bytesData = Convert.FromBase64String(data);
                var dataByte = privateKey.Decrypt(bytesData, false);
                return Convert.ToBase64String(dataByte);
             }
            catch (Exception ex)
            {
                return "";
            }
		}
