    public static void Main()
    {
        uint VALUE = 0xe3c6a7d1;
        using (BinaryReader binaryReader = new BinaryReader(File.Open("file", FileMode.Open)))
        {
            byte[] buffer = binaryReader.ReadBytes(20);
            for (int i = 0; i < buffer.Length - 4; i++)
            {
                uint currentValue = BitConverter.ToUInt32(buffer, i);
                if (currentValue == VALUE)
                    Console.WriteLine("FOUND!!!");
            }
        }
        Console.ReadLine();
    }
