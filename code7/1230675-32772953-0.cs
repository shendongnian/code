    static void Main(string[] args)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                // floats
                bw.Write(-456.678f);
                bw.Write(0f);
                bw.Write(float.MaxValue);
                // bytes
                bw.Write((byte)0);
                bw.Write((byte)120);
                bw.Write((byte)255);
                // uints
                bw.Write(0U);
                bw.Write(65000U);
                bw.Write(4294967295U);
            }
            var base64String = Convert.ToBase64String(ms.ToArray());
            Console.WriteLine(base64String);
        }
    }
