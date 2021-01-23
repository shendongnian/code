    public class PartialFileStream : FileStream {
        public PartialFileStream(string path, FileMode mode, FileAccess access, FileShare share, long firstChunkLength)
            : base(path, mode, access, share) {
            ReadTillPosition = firstChunkLength;
        }
        public long ReadTillPosition { get; private set; }
        public override int Read(byte[] array, int offset, int count) {
            if (base.Position >= this.ReadTillPosition)
                return 0;
            if (base.Position + count > this.ReadTillPosition)
                count = (int) (this.ReadTillPosition - base.Position);
            return base.Read(array, offset, count);
        }
    }
