    byte[] buffer = new byte[2048];
    StringBuilder messageData = new StringBuilder();
    int bytes = 0;
    bytes = sslStream.Read(buffer, 0, buffer.Length);
    Decoder decoder = Encoding.UTF8.GetDecoder();
    char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
    decoder.GetChars(buffer, 0, bytes, chars, 0);
    messageData.Append(chars);
    Console.Write(messageData.ToString());
