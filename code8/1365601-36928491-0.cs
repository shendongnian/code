    public class BigEndianBinaryReader : BinaryReader
        {
            public BigEndianBinaryReader(Stream input) : base(input)
            {
            }
            public BigEndianBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
            {
            }
            public BigEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
            {
            }
            public override UInt16 ReadUInt16()
            {
                return (UInt16)IPAddress.NetworkToHostOrder(base.ReadInt16());
            }
            public override UInt32 ReadUInt32()
            {
                return (UInt32)IPAddress.NetworkToHostOrder(base.ReadInt32());
            }
            public override UInt64 ReadUInt64()
            {
                return (UInt64)IPAddress.NetworkToHostOrder(base.ReadInt64());
            }
            public override Int16 ReadInt16()
            {
                return (Int16)IPAddress.NetworkToHostOrder(base.ReadInt16());
            }
            public override Int32 ReadInt32()
            {
                return (Int32)IPAddress.NetworkToHostOrder(base.ReadInt32());
            }
            public override Int64 ReadInt64()
            {
                return (Int64)IPAddress.NetworkToHostOrder(base.ReadInt64());
            }
        }
    
