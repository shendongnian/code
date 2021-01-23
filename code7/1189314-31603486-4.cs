    // The thing you send over a socket
    public class CompressedCaptureScreen
    {
        public CompressedCaptureScreen(int size)
        {
            this.Data = new byte[size];
            this.Size = 4;
        }
        public int Size;
        public byte[] Data;
    }
