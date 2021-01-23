    /// <summary>
    /// To convert Hex data string to bytes (i.e. 0x01455687)  given the data type
    /// </summary>
    /// <param name="hexString"></param>
    /// <param name="dataType"></param>
    /// <returns></returns>
    public static byte[] HexStringToBytes(string hexString) {
      try {
        if (hexString.Length >= 3) //must have minimum of length of 3
          if (hexString[0] == '0' && (hexString[1] == 'x' || hexString[1] == 'X'))
            hexString = hexString.Substring(2);
        int dataSize = (hexString.Length - 1) / 2;
        int expectedStringLength = 2 * dataSize;
        while (hexString.Length < expectedStringLength)
          hexString = "0" + hexString; //zero padding in the front
        int NumberChars = hexString.Length / 2;
        byte[] bytes = new byte[NumberChars];
        using (var sr = new StringReader(hexString)) {
          for (int i = 0; i < NumberChars; i++)
            bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
        }
        return bytes;
      } catch {
        return null;
      }
    }
