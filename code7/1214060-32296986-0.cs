    private static string ReadFromBuffer(FileStream fStream)
   {
        Byte[] bytes = new Byte[MAX_BUFFER_SIZE];
        string output = String.Empty;
        Decoder decoder8 = enc8.GetDecoder();
        while (fStream.Position < fStream.Length) {
           int nBytes = fStream.Read(bytes, 0, bytes.Length);
           int nChars = decoder8.GetCharCount(bytes, 0, nBytes);
           char[] chars = new char[nChars];
           nChars = decoder8.GetChars(bytes, 0, nBytes, chars, 0);
           output += new String(chars, 0, nChars);                                                     
        }
        return output;
    }
