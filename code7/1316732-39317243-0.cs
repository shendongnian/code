    //
    // Summary:
    //     Provides methods for encoding and decoding URLs when processing Web requests.
    public static class WebUtility
    {
        public static string HtmlDecode(string value);
        public static string HtmlEncode(string value);
        public static string UrlDecode(string encodedValue);
        public static byte[] UrlDecodeToBytes(byte[] encodedValue, int offset, int count);
        public static string UrlEncode(string value);
        public static byte[] UrlEncodeToBytes(byte[] value, int offset, int count);
    }
