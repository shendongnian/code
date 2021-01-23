     public string Encode(string input, byte[] key)
            {
                HMACSHA256 myhmacsha1 = new HMACSHA256(key);
                byte[] byteArray = Encoding.UTF8.GetBytes(input);
                MemoryStream stream = new MemoryStream(byteArray);
                byte[] hashValue = myhmacsha1.ComputeHash(stream);
                return Base64UrlEncoder.Encode(hashValue);
            }
