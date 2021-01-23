        public int MemoryReadInt(int baseAdresse, params int[] offsets)
        {
            return MemoryRead<int>(baseAdresse, sizeof(int), offsets);
        }
        public string MemoryReadString(int baseAdresse, uint readSize, params int[] offsets)
        {
            return MemoryRead<string>(baseAdresse, readSize, offsets);
        }
