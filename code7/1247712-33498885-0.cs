    public class EncodingConverter
    {
        public static string Utf16ToUtf8(string utf16String)
        {
            byte[] utf16Bytes = Encoding.Unicode.GetBytes(utf16String);
            byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16Bytes);
            return Encoding.Default.GetString(utf8Bytes);
        }
        public static string Utf8ToUtf16(string utf8String)
        {
            byte[] utf8Bytes = Encoding.Default.GetBytes(utf8String);
            byte[] utf16Bytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, utf8Bytes);
            return Encoding.Unicode.GetString(utf16Bytes);
        }
    }
