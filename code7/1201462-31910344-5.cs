    using (var br = new BinaryReader(new FileStream("mydata", FileMode.Open)))
    {
        i = br.ReadInt32();
        Console.WriteLine("Integer data: {0}", i);
        d = br.ReadDouble();
        Console.WriteLine("Double data: {0}", d);
        b = br.ReadBoolean();
        Console.WriteLine("Boolean data: {0}", b);
        s = br.ReadString();
        Console.WriteLine("String data: {0}", s);
    }
