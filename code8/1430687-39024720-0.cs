    /// <summary>
    /// Count valid UTF8-Bytes
    /// </summary>
    /// <returns>
    /// -1 = invalid UTF8-Bytes (may Latin1)
    /// 0 = ASCII only 7-Bit
    /// n = Count of UTF8-Bytes
    /// </returns>
    public static int Utf8CodedCharCounter(byte[] value) // result: 
    {
      int utf8Count = 0;
      for (int i = 0; i < value.Length; i++)
      {
        byte c = value[i];
        if ((c & 0x80) == 0) continue; // valid 7 Bit-ASCII -> skip
        if ((c & 0xc0) == 0x80) return -1; // wrong UTF8-Char
        // 2-Byte UTF8
        i++; if (i >= value.Length || (value[i] & 0xc0) != 0x80) return -1; // wrong UTF8-Char
        if ((c & 0xe0) == 0xc0) { utf8Count++; continue; }
        // 3-Byte UTF8
        i++; if (i >= value.Length || (value[i] & 0xc0) != 0x80) return -1; // wrong UTF8-Char
        if ((c & 0xf0) == 0xe0) { utf8Count++; continue; }
        // 4-Byte UTF8
        i++; if (i >= value.Length || (value[i] & 0xc0) != 0x80) return -1; // wrong UTF8-Char
        if ((c & 0xf8) == 0xf0) { utf8Count++; continue; }
        return -1; // invalid UTF8-Length
      }
      return utf8Count;
    }
