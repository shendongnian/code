    static string GetString(byte[] bytes)
    {
        UnicodeEncoding uEncoding = new UnicodeEncoding();
        string stringContent=uEncoding.GetString(bytes);
        return new string(stringContent);
    }
