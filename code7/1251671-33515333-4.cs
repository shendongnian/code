    [ProtoContract]
    internal class ArrayHolder
    {
        private ArrayHolder()
        {
            CollectionOfBytes = new byte[0] { };
        }
        internal ArrayHolder(IEnumerable<byte> bytesToUse)
        {
            CollectionOfBytes = bytesToUse.ToArray();
        }
        [ProtoIgnore]
        public byte[] CollectionOfBytes { get; set; }
        [ProtoMember(1, OverwriteList = true)]
        List<byte> ListOfBytes
        {
            get
            {
                if (CollectionOfBytes == null)
                    return null;
                return new List<byte>(CollectionOfBytes);
            }
            set
            {
                if (value == null)
                    return;
                CollectionOfBytes = value.ToArray();
            }
        }
    }
