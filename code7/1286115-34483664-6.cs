    unsafe static internal String CreateStringFromEncoding(
        byte* bytes, int byteLength, Encoding encoding)
    {
        int stringLength = encoding.GetCharCount(bytes, byteLength, null);
    
        if (stringLength == 0)
            return String.Empty;
        String s = FastAllocateString(stringLength);
        fixed (char* pTempChars = &s.m_firstChar)
        {
            encoding.GetChars(bytes, byteLength, pTempChars, stringLength, null);
        }
    }
