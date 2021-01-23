     public string utf16_encrypt(string input)
        {
            if (!string.IsNullOrEmpty(input)) return null;
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, this.encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(enc.GetBytes(input), 0, input.Length);
                cryptoStream.FlushFinalBlock();
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
