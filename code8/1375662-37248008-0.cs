    public static class Ext
    {
        public static void WriteByte(this BinaryWriter writer, byte b)
        {
            writer.Write(b);
        }
    }
