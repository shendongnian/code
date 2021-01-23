     static class BinaryReaderExtensionMethods
        {
            static public UInt16 ReadUInt16BE(this BinaryReader br)
            {
                return (UInt16)IPAddress.NetworkToHostOrder(br.ReadInt16());
            }
            static public UInt32 ReadUInt32BE(this BinaryReader br)
            {
                return (UInt32)IPAddress.NetworkToHostOrder(br.ReadInt32());
            }
            static public UInt64 ReadUInt64BE(this BinaryReader br)
            {
                return (UInt64)IPAddress.NetworkToHostOrder(br.ReadInt64());
            }
            static public Int16 ReadInt16BE(this BinaryReader br)
            {
                return (Int16)IPAddress.NetworkToHostOrder(br.ReadInt16());
            }
            static public Int32 ReadInt32BE(this BinaryReader br)
            {
                return (Int32)IPAddress.NetworkToHostOrder(br.ReadInt32());
            }
            static public Int64 ReadInt64BE(this BinaryReader br)
            {
                return (Int64)IPAddress.NetworkToHostOrder(br.ReadInt64());
            }
        }
