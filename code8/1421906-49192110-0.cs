    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Packs DateTimeOffset to bytes
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns>10 byte packed bytearray</returns>
        public static byte[] GetBytes(this DateTimeOffset dateTimeOffset)
        {
            return BitConverter.GetBytes(dateTimeOffset.Ticks).
               Concat(BitConverter.GetBytes((Int16)dateTimeOffset.Offset.TotalMinutes)).ToArray();
        }
        /// <summary>
        /// Reads 10 bytes from a buffer and turns back to DateTimeOffset
        /// </summary>
        /// <param name="bytes">Buffer</param>
        /// <param name="offset">Offset to read from</param>
        /// <returns></returns>
        public static DateTimeOffset FromBytes(byte[] bytes, int offset)
        {
            var ticks = BitConverter.ToInt64(bytes, offset);
            var offsetMinutes = BitConverter.ToInt16(bytes, offset + 8);
            return new DateTimeOffset(ticks, TimeSpan.FromMinutes(offsetMinutes));
        }
    }
