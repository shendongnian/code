        public static void WriteDefaultValues()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                writer.Write(0);
                writer.Write(1);
                writer.Write(2);
                writer.Write(3);
            }
        }
