    namespace System.Web
    {
        //
        // Summary:
        //     Provides methods for encoding and decoding URLs when processing Web requests.
        //     This class cannot be inherited.
        public sealed class HttpUtility
        {
            public HttpUtility();
            public static string HtmlAttributeEncode(string s);
            public static void HtmlAttributeEncode(string s, TextWriter output); 
            public static string HtmlDecode(string s);
            public static void HtmlDecode(string s, TextWriter output);
            public static string HtmlEncode(string s);
            public static string HtmlEncode(object value);
            public static void HtmlEncode(string s, TextWriter output);
            public static string JavaScriptStringEncode(string value);
            public static string JavaScriptStringEncode(string value, bool addDoubleQuotes);
            public static NameValueCollection ParseQueryString(string query);
            public static NameValueCollection ParseQueryString(string query, Encoding encoding);
            public static string UrlDecode(string str, Encoding e);
            public static string UrlDecode(byte[] bytes, int offset, int count, Encoding e);
            public static string UrlDecode(string str);
            public static string UrlDecode(byte[] bytes, Encoding e);
            public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count);
            public static byte[] UrlDecodeToBytes(string str, Encoding e);
            public static byte[] UrlDecodeToBytes(byte[] bytes);
            public static byte[] UrlDecodeToBytes(string str);
            public static string UrlEncode(string str);
            public static string UrlEncode(string str, Encoding e);
            public static string UrlEncode(byte[] bytes);
            public static string UrlEncode(byte[] bytes, int offset, int count);
            public static byte[] UrlEncodeToBytes(string str);
            public static byte[] UrlEncodeToBytes(byte[] bytes);
            public static byte[] UrlEncodeToBytes(string str, Encoding e);
            public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count);
            [Obsolete("This method produces non-standards-compliant output and has interoperability issues. The preferred alternative is UrlEncode(String).")]
            public static string UrlEncodeUnicode(string str);
            [Obsolete("This method produces non-standards-compliant output and has interoperability issues. The preferred alternative is UrlEncodeToBytes(String).")]
            public static byte[] UrlEncodeUnicodeToBytes(string str);
            public static string UrlPathEncode(string str);
        }
    }
