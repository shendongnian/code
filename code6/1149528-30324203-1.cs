      string key = "52320e181a481f5e19507a75b3cae4d74d5cfbc328f7f2b738e9fb06b2e05b55b632c1c3d331dcf3baacae8d3000594f839d770f2080910b52b7b8beb3458c08";
            string payload = "1116Software program14200503031234341420050303123434";
            int NumberChars = key.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(key.Substring(i, 2), 16);
            byte[] keyInBytes = bytes;
          
            byte[] payloadInBytes = Encoding.UTF8.GetBytes(payload);
            var md5 = new HMACMD5(key);//This should match with service key
            byte[] hash = md5.ComputeHash(payloadInBytes);
            var result = BitConverter.ToString(hash).Replace("-", string.Empty);
