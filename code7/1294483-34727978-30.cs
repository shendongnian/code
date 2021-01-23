    public class HuffmanStream : Stream {
       private Stream _stream = new MemoryStream();
       private static byte[] _header = ... ;
       public HuffmanStream( ... ) {
          ...
          _stream.Write(_header, 0, _header.Length)
          // the stream already has the header written at instantiation time
       }
    }
