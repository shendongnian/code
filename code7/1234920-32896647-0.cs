    public static class Crc32
    {
        private static readonly uint[] _table =
        {
            0x00000000, 0x77073096, 0xee0e612c, 0x990951ba,
            ...... rest of elements hidden
        };
        public static uint ComputeChecksum(byte[] bytes)
        {
            var crc = 0xffffffff;
            for (var i = 0; i < bytes.Length; i++)
            {
                var t = bytes[i];
                var index = (byte) ((crc & 0xff) ^ t);
                crc = (crc >> 8) ^ _table[index];
            }
            return ~crc; // or maybe return crc;
        }
    }
