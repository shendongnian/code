    public class HuffmanStream : Stream {
       private Stream _stream = new MemoryStream();
       private byte[] _header = ... ;
       public HuffmanStream( ... ) {
          ...
          stream.Write(_header, 0, _header.Length)
          // the stream already has the header written at instantiation time
       }
    }
