        internal string UrlDecode(string value, Encoding encoding) {
            if (value == null) {
                return null;
            }
 
            int count = value.Length;
            UrlDecoder helper = new UrlDecoder(count, encoding);
 
            // go through the string's chars collapsing %XX and %uXXXX and
            // appending each char as char, with exception of %XX constructs
            // that are appended as bytes
 
            for (int pos = 0; pos < count; pos++) {
                char ch = value[pos];
 
                if (ch == '+') {
                    ch = ' ';
                }
                else if (ch == '%' && pos < count - 2) {
                    if (value[pos + 1] == 'u' && pos < count - 5) {
                        int h1 = HttpEncoderUtility.HexToInt(value[pos + 2]);
                        int h2 = HttpEncoderUtility.HexToInt(value[pos + 3]);
                        int h3 = HttpEncoderUtility.HexToInt(value[pos + 4]);
                        int h4 = HttpEncoderUtility.HexToInt(value[pos + 5]);
 
                        if (h1 >= 0 && h2 >= 0 && h3 >= 0 && h4 >= 0) {   // valid 4 hex chars
                            ch = (char)((h1 << 12) | (h2 << 8) | (h3 << 4) | h4);
                            pos += 5;
 
                            // only add as char
                            helper.AddChar(ch);
                            continue;
                        }
                    }
                    else {
                        int h1 = HttpEncoderUtility.HexToInt(value[pos + 1]);
                        int h2 = HttpEncoderUtility.HexToInt(value[pos + 2]);
 
                        if (h1 >= 0 && h2 >= 0) {     // valid 2 hex chars
                            byte b = (byte)((h1 << 4) | h2);
                            pos += 2;
 
                            // don't add as char
                            helper.AddByte(b);
                            continue;
                        }
                    }
                }
 
                if ((ch & 0xFF80) == 0)
                    helper.AddByte((byte)ch); // 7 bit have to go as bytes because of Unicode
                else
                    helper.AddChar(ch);
            }
 
            return Utf16StringValidator.ValidateString(helper.GetString());
        }
