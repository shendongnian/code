        private static string GetString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            while (index < bytes.Length)
            {
                if ((bytes[index] & 0x7F) == bytes[index])
                {
                    Int32 code = bytes[index];
                    byte[] codeBytes = BitConverter.GetBytes(code);
                    builder.Append(UnicodeEncoding.UTF32.GetString(codeBytes));
                    index += 1;
                }
                else if (((bytes[index] & 0xDF) == bytes[index]) && (index + 1) < bytes.Length
                                                                 && ((bytes[index + 1] & 0xBF) == bytes[index + 1]))
                {
                    Int32 code = ((bytes[index + 0] & 0x1F) << 06) +
                                 ((bytes[index + 1] & 0x7F) << 00);
                    byte[] codeBytes = BitConverter.GetBytes(code);
                    builder.Append(UnicodeEncoding.UTF32.GetString(codeBytes));
                    index += 2;
                }
                else if (((bytes[index] & 0xEF) == bytes[index]) && (index + 2) < bytes.Length
                                                                 && ((bytes[index + 1] & 0xBF) == bytes[index + 1])
                                                                 && ((bytes[index + 2] & 0xBF) == bytes[index + 2]))
                {
                    Int32 code = ((bytes[index + 0] & 0x0F) << 12) +
                                 ((bytes[index + 1] & 0x7F) << 06) +
                                 ((bytes[index + 2] & 0x7F) << 00);
                    byte[] codeBytes = BitConverter.GetBytes(code);
                    builder.Append(UnicodeEncoding.UTF32.GetString(codeBytes));
                    index += 3;
                }
                else if (((bytes[index] & 0xF7) == bytes[index]) && (index + 3) < bytes.Length
                                                                 && ((bytes[index + 1] & 0xBF) == bytes[index + 1])
                                                                 && ((bytes[index + 2] & 0xBF) == bytes[index + 2])
                                                                 && ((bytes[index + 3] & 0xBF) == bytes[index + 3]))
                {
                    Int32 code = ((bytes[index + 0] & 0x07) << 18) +
                                 ((bytes[index + 1] & 0x7F) << 12) +
                                 ((bytes[index + 2] & 0x7F) << 06) +
                                 ((bytes[index + 3] & 0x7F) << 00);
                    byte[] codeBytes = BitConverter.GetBytes(code);
                    builder.Append(UnicodeEncoding.UTF32.GetString(codeBytes));
                    index += 4;
                }
                else if (((bytes[index] & 0xFB) == bytes[index]) && (index + 4) < bytes.Length
                                                                 && ((bytes[index + 1] & 0xBF) == bytes[index + 1])
                                                                 && ((bytes[index + 2] & 0xBF) == bytes[index + 2])
                                                                 && ((bytes[index + 3] & 0xBF) == bytes[index + 3])
                                                                 && ((bytes[index + 4] & 0xBF) == bytes[index + 4]))
                {
                    Int32 code = ((bytes[index + 0] & 0x03) << 24) +
                                 ((bytes[index + 1] & 0x7F) << 18) +
                                 ((bytes[index + 2] & 0x7F) << 12) +
                                 ((bytes[index + 3] & 0x7F) << 06) +
                                 ((bytes[index + 4] & 0x7F) << 00);
                    byte[] codeBytes = BitConverter.GetBytes(code);
                    builder.Append(UnicodeEncoding.UTF32.GetString(codeBytes));
                    index += 5;
                }
                else if (((bytes[index] & 0xFD) == bytes[index]) && (index + 5) < bytes.Length
                                                                 && ((bytes[index + 1] & 0xBF) == bytes[index + 1])
                                                                 && ((bytes[index + 2] & 0xBF) == bytes[index + 2])
                                                                 && ((bytes[index + 3] & 0xBF) == bytes[index + 3])
                                                                 && ((bytes[index + 4] & 0xBF) == bytes[index + 4])
                                                                 && ((bytes[index + 5] & 0xBF) == bytes[index + 5]))
                {
                    Int32 code = ((bytes[index + 0] & 0x01) << 30) +
                                 ((bytes[index + 1] & 0x7F) << 24) +
                                 ((bytes[index + 2] & 0x7F) << 18) +
                                 ((bytes[index + 3] & 0x7F) << 12) +
                                 ((bytes[index + 4] & 0x7F) << 06) +
                                 ((bytes[index + 5] & 0x7F) << 00);
                    byte[] codeBytes = BitConverter.GetBytes(code);
                    builder.Append(UnicodeEncoding.UTF32.GetString(codeBytes));
                    index += 6;
                }
                else
                    throw new Exception("Wrong UTF-8 format");
            }
            return builder.ToString();
        }
        public static void Main()
        {
            string source = "Disk:%FC%80%80%80%80%AFFolder";
            byte[] bytes = HttpUtility.UrlDecodeToBytes(source);
            string result = GetString(bytes);
        }
