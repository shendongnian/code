    class ZeroStream : System.IO.Stream
    {
        public override int Read (byte[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++) {
                buffer [offset + i] = 0;
            }
            
            return count;
        }
        
        public override bool CanRead {
            get { return true; }
        }
        ... the rest is not implemented
    }
