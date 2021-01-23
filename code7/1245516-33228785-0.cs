    using System.IO;
    public static void WriteBytes(byte[] bytes, string filename)
    {
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
        {
            writer.Write(bytes);
        }
    }
