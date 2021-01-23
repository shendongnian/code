    public class WatitingStream : Stream
    {
        private BlockingCollection<byte[]> Packets = new BlockingCollection<byte[]>();
        private byte[] IncompletePacket;
        private int IncompletePacketOffset;
        public WatitingStream()
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Packets.CompleteAdding();
            }
            base.Dispose(disposing);
        }
        public override bool CanRead
        {
            get { return Packets.IsCompleted; }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return Packets.IsAddingCompleted; }
        }
        public override void Flush()
        {
        }
        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (count == 0)
            {
                return 0;
            }
            byte[] packet;
            int packetOffset;
            if (IncompletePacket != null)
            {
                packet = IncompletePacket;
                packetOffset = IncompletePacketOffset;
            }
            else
            {
                if (Packets.IsCompleted)
                {
                    return 0;
                }
                packet = Packets.Take();
                packetOffset = 0;
            }
            int read = Math.Min(packet.Length - packetOffset, count);
            Buffer.BlockCopy(packet, packetOffset, buffer, offset, read);
            packetOffset += read;
            if (packetOffset < packet.Length)
            {
                IncompletePacket = packet;
                IncompletePacketOffset = packetOffset;
            }
            else
            {
                IncompletePacket = null;
                IncompletePacketOffset = 0;
            }
            return read;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (count == 0)
            {
                return;
            }
            byte[] packet = new byte[count];
            Buffer.BlockCopy(buffer, offset, packet, 0, count);
            Packets.Add(packet);
        }
    }
