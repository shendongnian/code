    public struct Person
    {
        public int Age;     // 4 bytes
        public short Id;    // 2 bytes
        public byte Marks;  // 1 byte + 1 byte for padding
    }
    public struct Person
    {
        public byte Marks; // 1 byte + 3 bytes for padding
        public int Age;    // 4 bytes
        public short Id;   // 2 bytes + 2 bytes for padding
    }
