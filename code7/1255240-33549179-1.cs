    public static void Main()
    {
        uint VALUE = 0xe3c6a7d1;
        using (BinaryReader binaryReader = new BinaryReader(File.Open("File.bin", FileMode.Open)))
        {
            byte[] buffer = binaryReader.ReadBytes(20);
            for (int i = 0; i < buffer.Length - 4; i++)
            {
                byte[] temp = new byte[4];
                Buffer.BlockCopy(buffer, i, temp, 0, 4);
                temp = temp.Reverse().ToArray();
                uint currentValue = BitConverter.ToUInt32(temp, 0);
                if (currentValue == VALUE)
                    Console.WriteLine("FOUND!!!");
            }
        }
        Console.ReadLine();
    }
