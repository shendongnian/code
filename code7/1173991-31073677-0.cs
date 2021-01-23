    // If you want to use UTF8:
    // var encoding = (Encoding)Encoding.UTF8.Clone();
    var encoding = Encoding.GetEncoding("iso-8859-1"); 
    var decoder = encoding.GetDecoder();
    //Encoding.ASCII
    var headerLines = new List<string>();
    var sb = new StringBuilder();
    byte[] bytes = new byte[1];
    char[] chars = new char[2];
    while (true)
    {
        int curr = stream.ReadByte();
        char ch = '\0';
        bool newLine = false;
        if (curr == -1)
        {
            newLine = true;
        }
        else
        {
            bytes[0] = (byte)curr;
            // There is the possibility of a partial invalid 
            // character (first byte of UTF8) plus a new valid 
            // character. In this case decoder.GetChars will
            // return 2 chars
            int count = decoder.GetChars(bytes, 0, 1, chars, 0);
            for (int i = 0; i < count; i++)
            {
                ch = chars[i];
                if (ch == '\n')
                {
                    newLine = true;
                }
                else
                {
                    sb.Append(ch);
                }
            }
        }
        if (newLine)
        {
            string str = sb.ToString();
            // Handling of \r\n
            if (ch == '\n' && str[str.Length - 1] == '\r')
            {
                str = str.Remove(str.Length - 1);
            }
            str = str.Trim();
            if (str.Length != 0)
            {
                headerLines.Add(str);
                sb.Clear();
            }
            else
            {
                break;
            }
        }
        if (curr == -1)
        {
            break;
        }
    }
