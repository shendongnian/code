    public class MultipartParser
 
    {
        public MultipartParser(Stream stream)
    {
      this.Parse(stream);
    }
    private void Parse(Stream stream)
    {
      this.Success = false;
      if(!stream.CanRead)
        return;
      // Read the stream into a byte array
      byte[] data = MultipartParser.ToByteArray(stream);
      if (data.Length < 1)
        return;
      // finding the delimiter (the string in the beginning and end of the file
      int delimeterIndex = MultipartParser.SimpleBoyerMooreSearch(data, Encoding.UTF8.GetBytes("\r\n")); // here we got delimeter index
      if (delimeterIndex == -1) return;
      byte[] delimeterBytes = new byte[delimeterIndex];
      Array.Copy(data, delimeterBytes, delimeterIndex);
      // removing the very first couple of lines, till we get the beginning of the JPG file
      byte[] newLineBytes = Encoding.UTF8.GetBytes("\r\n\r\n");
      int startIndex = 0;
      startIndex = MultipartParser.SimpleBoyerMooreSearch(data, newLineBytes);
      if (startIndex == -1)
        return;
      int startIndexWith2Lines = startIndex + 4; // 4 is the bytes of "\r\n\r\n"
      int newLength = data.Length - startIndexWith2Lines;
      byte[] newByteArray = new byte[newLength];
      Array.Copy(data, startIndex + 4, newByteArray, 0, newLength - 1);
      // check for the end of the stream, is ther same delimeter
      int isThereDelimeterInTheEnd = MultipartParser.SimpleBoyerMooreSearch(newByteArray, delimeterBytes);
      if (isThereDelimeterInTheEnd == -1) return; // the file corrupted so
      int endIndex = isThereDelimeterInTheEnd - delimeterBytes.Length;
      byte[] lastArray = new byte[endIndex];
      Array.Copy(newByteArray, 0, lastArray, 0, endIndex);
      this.FileContents = lastArray;
      this.Success = true;
    }
    static byte[] GetBytes(string str)
    {
      byte[] bytes = new byte[str.Length * sizeof(char)];
      System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
      return bytes;
    }
    static string GetString(byte[] bytes)
    {
      char[] chars = new char[bytes.Length / sizeof(char)];
      System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
      return new string(chars);
    }
    public static int SimpleBoyerMooreSearch(byte[] haystack, byte[] needle)
    {
      int[] lookup = new int[256];
      for (int i = 0; i < lookup.Length; i++) { lookup[i] = needle.Length; }
      for (int i = 0; i < needle.Length; i++)
      {
        lookup[needle[i]] = needle.Length - i - 1;
      }
      int index = needle.Length - 1;
      byte lastByte = needle.Last();
      while (index < haystack.Length)
      {
        var checkByte = haystack[index];
        if (haystack[index] == lastByte)
        {
          bool found = true;
          for (int j = needle.Length - 2; j >= 0; j--)
          {
            if (haystack[index - needle.Length + j + 1] != needle[j])
            {
              found = false;
              break;
            }
          }
          if (found)
            return index - needle.Length + 1;
          else
            index++;
        }
        else
        {
          index += lookup[checkByte];
        }
      }
      return -1;
    }
    private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
    {
      int index = 0;
      int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);
      if (startPos != -1)
      {
        while ((startPos + index) < searchWithin.Length)
        {
          if (searchWithin[startPos + index] == serachFor[index])
          {
            index++;
            if (index == serachFor.Length)
            {
              return startPos;
            }
          }
          else
          {
            startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
            if (startPos == -1)
            {
              return -1;
            }
            index = 0;
          }
        }
      }
      return -1;
    }
    public static byte[] ToByteArray(Stream stream)
    {
      byte[] buffer = new byte[32768];
      using (MemoryStream ms = new MemoryStream())
      {
        while (true)
        {
          int read = stream.Read(buffer, 0, buffer.Length);
          if (read <= 0)
            return ms.ToArray();
          ms.Write(buffer, 0, read);
        }
      }
    }
    public bool Success
    {
      get;
      private set;
    }
    public byte[] FileContents
    {
      get;
      private set;
    }
  
    }
