    if (imei == "xyz")
    {
        string Password = "01";
        byte[] PasswordBytes = Password.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();
        stream.Write(PasswordBytes, 0, PasswordBytes.Length);
        Library.WriteErrorLog("Password Sent for- " + StrInput) ;}
