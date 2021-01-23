    var rfc2898 = new Rfc2898DeriveBytes("password", new byte[8]);
    
    using (var aes = new AesManaged())
    {
        aes.Key = rfc2898.GetBytes(32);
        aes.IV = rfc2898.GetBytes(16);
        var originalIV = aes.IV; // keep a copy
    
        // Prepare sample plaintext that has no padding
        aes.Padding = PaddingMode.None;
        var plaintext = Encoding.UTF8.GetBytes("this plaintext has 32 characters");
        byte[] ciphertext;
        using (var encryptor = aes.CreateEncryptor())
        {
            ciphertext = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
            Console.WriteLine("ciphertext: " + BitConverter.ToString(ciphertext));
        }
    
        // From this point on we do everything with PKCS#7 padding
        aes.Padding = PaddingMode.PKCS7;
    
        // This won't decrypt -- wrong padding
        try
        {
            using (var decryptor = aes.CreateDecryptor())
            {
                var oops = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("caught: " + e.Message);
        }
    
        // Last block of ciphertext is used as IV to encrypt a little bit more
        var lastBlock = new byte[16];
        var modifiedCiphertext = new byte[ciphertext.Length + 16];
    
        Array.Copy(ciphertext, ciphertext.Length - 16, lastBlock, 0, 16);
        aes.IV = lastBlock;
    
        using (var encryptor = aes.CreateEncryptor())
        {
            var dummy = Encoding.UTF8.GetBytes("$");
            var padded = encryptor.TransformFinalBlock(dummy, 0, dummy.Length);
    
            // Set modifiedCiphertext = ciphertext + padded
            Array.Copy(ciphertext, modifiedCiphertext, ciphertext.Length);
            Array.Copy(padded, 0, modifiedCiphertext, ciphertext.Length, padded.Length);
            Console.WriteLine("modified ciphertext: " + BitConverter.ToString(modifiedCiphertext));
        }
    
        // Put back the original IV, and now we can decrypt...
        aes.IV = originalIV;
    
        using (var decryptor = aes.CreateDecryptor())
        {
            var recovered = decryptor.TransformFinalBlock(modifiedCiphertext, 0, modifiedCiphertext.Length);
            var str = Encoding.UTF8.GetString(recovered);
            Console.WriteLine(str);
    
            // Now you can remove the '$' from the end
        }
    }
