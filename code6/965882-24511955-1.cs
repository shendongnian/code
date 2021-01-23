    public static void callbackAuth(
        [MarshalAs(UnmanagedType.LPStr)]String server,
        [MarshalAs(UnmanagedType.LPStr)]String share,
        IntPtr workgroup, int workgroupMaxLen,
        IntPtr username, int usernameMaxLen,
        IntPtr password, int passwordMaxLen) 
    {
        //server = "targetserver";
        //share = "Public"; 
        // should not be assigned - 
        // you must provide credentials for specified server
    
        SetString(username, "Management.Service", username.Length);
        SetString(password, @"{SomeComplexPassword}", password.Length);
        SetString(workgroup, "targetserver", workgroup.Length);
    }
    
    private void SetString(IntPtr dest, string str, int maxLen)
    {
        // include null string terminator
        byte[] buffer = Encoding.ASCII.GetBytes(str + "\0");
        if (buffer.Length >= maxLen) return; // buffer is not big enough
    
        Marshal.Copy(buffer, 0, dest, buffer.Length);
    }
