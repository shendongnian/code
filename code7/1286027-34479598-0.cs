    int c = 0;
    int runs = 0;
    byte[] data = new byte[400]; // byte array setup
    // read hex values (loop) and convert to acsii string
    BinaryReader reader = new BinaryReader(new FileStream("C:\File", FileMode.Open, FileAccess.Read, FileShare.None));
    reader.BaseStream.Position = 0x1290;
            
    while (c == 0)
    {
        data[runs] = reader.ReadByte();
        if (data[runs] == 0x00)
        {
           c = 1; // stop loop at .ReadByte = 0x00
        }
        runs++;
    }
    reader.Close();
    // hex to acsii string, removing null bytes
    result = Encoding.Default.GetString(data.Where(x => x != 0).ToArray());
