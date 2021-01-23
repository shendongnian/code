    byte[] bytesToBeEncrypted = File.ReadAllBytes(files[i]);
    byte[] passwordBytes = Encoding.UTF8.GetBytes(passWord);
    // Hash the password with SHA256
    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
    byte[] bytesCyrpt = new byte[0];
    if (Mode == "Encrypt")
    {
        bytesCyrpt = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
        File.WriteAllBytes(encryptedFileName(files[i]), bytesCyrpt);
        File.Delete(files[i]);
    }
    else
    {
        bytesCyrpt = AES_Decrypt(bytesToBeEncrypted, passwordBytes);
        File.WriteAllBytes(decryptFileName(files[i]), bytesCyrpt);
    }
