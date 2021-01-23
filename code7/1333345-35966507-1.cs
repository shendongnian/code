    using (var fInput = new FileStream(fileInput, FileMode.Open, FileAccess.Read))
    using (var ms = new MemoryStream())
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
 		des.Key = ASCIIEncoding.ASCII.GetBytes(password);
 		des.IV = ASCIIEncoding.ASCII.GetBytes(password);
 
 		ICryptoTransform encryptor = des.CreateEncryptor();
 		using (var cryptostream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            await fInput.CopyToAsync(cryptostream);
        }
 
        // Do something with ms here.
    }
