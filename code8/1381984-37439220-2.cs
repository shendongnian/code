    public class PartialFileStream : FileStream {
        public PartialFileStream(string path, FileMode mode, FileAccess access, FileShare share, long firstChunkLength)
            : base(path, mode, access, share) {
            Advance(firstChunkLength);
        }
        public long ReadTillPosition { get; private set; }
        private long _length;
        public override long Length => _length;
        public void Advance(long nextChunkLength) {
            this.ReadTillPosition += nextChunkLength;
            if (ReadTillPosition > base.Length) {
                // if we are outside the stream, adjust
                var diff = ReadTillPosition - base.Length;
                nextChunkLength -= diff;
                ReadTillPosition = base.Length;
                if (nextChunkLength < 0)
                    nextChunkLength = 0;
            }
            _length = nextChunkLength;
        }
        public override int Read(byte[] array, int offset, int count) {
            if (base.Position >= this.ReadTillPosition)
                return 0;
            if (base.Position + count > this.ReadTillPosition)
                count = (int) (this.ReadTillPosition - base.Position);
            return base.Read(array, offset, count);
        }
    }
