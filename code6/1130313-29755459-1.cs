        public static void WriteDefaultValues()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                writer.Write((byte)0);
                writer.Write((byte)1);
                writer.Write((byte)2);
                writer.Write((byte)3);
            }
        }
