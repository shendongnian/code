    public abstract class AbstractHeader
    {
        public abstract int HeaderSize { get; }
        public virtual byte[] Content { get; set; }
        protected AbstractHeader() { }
        protected AbstractHeader(byte[] bytes)
        {
            Content = bytes;
        }
    }
    public class BaseHeader : AbstractHeader
    {
        public override int HeaderSize => sizeof (byte);
    }
    public class BiggerHeader : AbstractHeader
    {
        public override int HeaderSize => sizeof (byte) + sizeof (UInt32);
        public BiggerHeader(BaseHeader header) : base(header.Content)
        {
        }
    }
