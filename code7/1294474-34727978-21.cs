    public static class StreamExtensions {
       // include BlockCopy code from above
       public static void WriteHuffmanHeader(this Stream stream) {
          var header = GetHeaderClone();
          stream.Write(header, 0, header.Length);
       }
    }
