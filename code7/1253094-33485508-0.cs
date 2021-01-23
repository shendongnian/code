    //input params: byte[] buff - buffer, byte[] Sys.PrivateKey;
    using (System.Security.Cryptography.RijndaelManaged rijndael = new System.Security.Cryptography.RijndaelManaged())
    {
    	byte[] iv = new byte[16];		//Here goes your IV! If its not zeros, assign it other way
    	for (int i = 0; i < 16; i++)
    		iv[i] = 0;
    	rijndael.Padding = PaddingMode.PKCS7;
    	rijndael.Mode = CipherMode.CBC;
    	rijndael.Key = Sys.PrivateKey;	//Here goes byte[] buffer with your key, in my case Sys.PrivateKey
    	rijndael.KeySize = 128;
    	rijndael.BlockSize = 128;
    	rijndael.IV = iv;
    	//Some debugging:
    	//Sys.LogWrite("Decrypt input bytes length: " + buff.Length + ", keyLength: " + Sys.PrivateKey.Length);
    	//Sys.LogWriteBuffer("Input bytes", buff);
    	//Sys.LogWriteBuffer("Input key", Sys.PrivateKey);
    	ICryptoTransform decryptor = rijndael.CreateDecryptor(Sys.PrivateKey, iv);
    	System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(buff);
    	CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
    	byte[] output = new byte[buff.Length];
    	int readBytes = cryptoStream.Read(output, 0, output.Length);
    	String dataString = System.Text.Encoding.UTF8.GetString(output,0,readBytes);
    	//Some debugging again:
    	//Sys.LogWrite("real data/"+readBytes+": {0}", dataString);
    }
