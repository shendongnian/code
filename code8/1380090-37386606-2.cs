    string hexString = "00 01 02 03 04 05 06 07 08 09 0a 0b 0c 0d 0e 0f 10 11 12 13 14 15 16 17 18";
    using (var stream = new MemoryStream(StringToByteArray(hexString)))
    using (var reader = new BinaryReader(stream))
    {
        int value1 = reader.ReadByte(); // 1 byte.
        Console.WriteLine(value1);
        int value2 = reader.ReadByte(); // 1 byte.
        Console.WriteLine(value2);
        int value3 = reader.ReadInt32(); // 4 bytes.
        Console.WriteLine(value3);
        long value4 = LongFromBytes(reader.ReadBytes(5)); // 5 bytes into a long.
        Console.WriteLine(value4);
    }
