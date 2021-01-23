    class Binary
    {
        public Binary(byte[] value)
        {
            this.Value = value.ToArray();
        }
        public byte[] Value { get; private set; }
        // User-defined conversion from Binary to int 
        public static implicit operator int(Binary b)
        {
            return b.Value[0] + (b.Value[1] << 8) + (b.Value[2] << 16) + (b.Value[3] << 24);
        }
        //  User-defined conversion from int to Binary
        public static implicit operator Binary(int i)
        {
            var result = new byte[4];
            result[0] = (byte)(i & 0xFF);
            result[1] = (byte)(i >> 8 & 0xFF);
            result[2] = (byte)(i >> 16 & 0xFF);
            result[3] = (byte)(i >> 24 & 0xFF);
            return new Binary(result);
        }
    }
