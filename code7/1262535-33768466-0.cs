    /// <summary>
    /// Convert a zero terminated byte array to a string.
    /// </summary>
    /// <param name="byteArray"></param>
    /// <returns></returns>
    private static string ZeroTerminatedByteArrayToString(byte[] byteArray)
    {
      // This routine is used to map a byte array unmodified to a string
      // Each character is stored with as a double byte with leading zero.
      // Using the encodings to convert will try and remap some characters
      // System.Text.Encoding.GetEncoding("437").GetString(byteArray);
      // System.Text.Encoding.UTF8.GetString(byteArray);
      
      string result = "";
      for (int i = 0; i < byteArray.Length; i++) {
        if (byteArray[i] == 0) { break; }
        result = result + (char)byteArray[i];
      }
      return result;
    }
