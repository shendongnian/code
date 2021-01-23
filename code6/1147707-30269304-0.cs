    private static byte[] Base64UrlDecode(string arg)
    {
        // Convert from base64url string to base64 string
        string s = arg;
        s = s.Replace('-', '+').Replace('_', '/');
        switch(s.Length % 4)
        {
            case 0:
                break;              // No pad chars in this case
            case 2:
                s += "==";
                break;              // Two pad chars
            case 3:
                s += "=";
                break;              // One pad char
            default:
                throw new Exception("Illegal base64url string!");
        }
    
        return Convert.FromBase64String(s);
    }
