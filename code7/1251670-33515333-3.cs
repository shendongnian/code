    [ProtoContract]
    internal class ListHolder
    {
        private ListHolder()
        {
            CollectionOfBytes = new List<byte>();
        }
        internal ListHolder(IEnumerable<byte> bytesToUse)
        {
            CollectionOfBytes = bytesToUse.ToList();
        }
        [ProtoMember(1, IsPacked = true)]
        public List<byte> CollectionOfBytes { get; set; }
    }
