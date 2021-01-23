    const int MaxLogMessageLength = 31839 ;
    int n = Encoding.Unicode.GetByteCount(message);
    if (n > MaxLogMessageLength)
    {
        message = message.Substring(0, MaxLogMessageLength/2); // Most UTF16 chars are 2 bytes.
        while (Encoding.Unicode.GetByteCount(message) > MaxLogMessageLength)
            message = message.Substring(0, message.Length-1);
    }
