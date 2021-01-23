        public static string GetStringFromEncodedBytes(byte[] bytes) {
            Encoding encoding = Encoding.Default;
            int skipBytes = 0;
            if (bytes[0] == 0x2b && bytes[1] == 0x2f && bytes[2] == 0x76) {
                encoding = Encoding.UTF7;
                skipBytes = 3;
            }
            if (bytes[0] == 0xef && bytes[1] == 0xbb && bytes[2] == 0xbf)
            {
                encoding = Encoding.UTF8;
                skipBytes = 3;
            }
            if (bytes[0] == 0xff && bytes[1] == 0xfe)
            {
                encoding = Encoding.Unicode;
                skipBytes = 2;
            }
            if (bytes[0] == 0xfe && bytes[1] == 0xff)
            {
                encoding = Encoding.BigEndianUnicode;
                skipBytes = 2;
            }
            if (bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0xfe && bytes[3] == 0xff)
            {
                encoding = Encoding.UTF32;
                skipBytes = 4;
            }
            return encoding.GetString(bytes.Skip(skipBytes).ToArray());
        }
