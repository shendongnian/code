    public static char Chr(int CharCode)
    {
        char ch;
        if ((CharCode < -32768) || (CharCode > 0xffff))
        {
            throw new ArgumentException(Utils.GetResourceString("Argument_RangeTwoBytes1", new string[] { "CharCode" }));
        }
        if ((CharCode >= 0) && (CharCode <= 0x7f))
        {
            return Convert.ToChar(CharCode);
        }
        try
        {
            int num;
            Encoding encoding = Encoding.GetEncoding(Utils.GetLocaleCodePage());
            if (encoding.IsSingleByte && ((CharCode < 0) || (CharCode > 0xff)))
            {
                throw ExceptionUtils.VbMakeException(5);
            }
            char[] chars = new char[2];
            byte[] bytes = new byte[2];
            Decoder decoder = encoding.GetDecoder();
            if ((CharCode >= 0) && (CharCode <= 0xff))
            {
                bytes[0] = (byte) (CharCode & 0xff);
                num = decoder.GetChars(bytes, 0, 1, chars, 0);
            }
            else
            {
                bytes[0] = (byte) ((CharCode & 0xff00) >> 8);
                bytes[1] = (byte) (CharCode & 0xff);
                num = decoder.GetChars(bytes, 0, 2, chars, 0);
            }
            ch = chars[0];
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return ch;
    }
