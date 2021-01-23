    using (CryptoStream cryptostream = new CryptoStream(fileEncrypted, desencrypt, CryptoStreamMode.Write))
    {
        // Read in the input file and write to the output file while passing through the crypto stream object using the password provided
        byte[] bytearrayinput = new byte[fileInput.Length - 1];
        fileInput.Read(bytearrayinput, 0, bytearrayinput.Length);
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
    }
