    var srx = new StartReadXML();
    srx.CmdID = 3;
    srx.CmdName = "sreedhar";
    srx.Description = "Kumar";
    // Write to buffer
    byte[] buffer;
    using (var ms = new MemoryStream())
    {
        using (var bw = new BinaryWriter(ms, Encoding.UTF8))
        {
            bw.Write(srx.CmdID);
            bw.Write(srx.CmdName);
            bw.Write(srx.Description);
        }
        buffer = ms.ToArray();
    }
    // Read
    var srx2 = new StartReadXML();
    using (var ms = new MemoryStream(buffer))
    {
        using (var br = new BinaryReader(ms, Encoding.UTF8))
        {
            srx2.CmdID = br.ReadInt32();
            srx2.CmdName = br.ReadString();
            srx2.Description = br.ReadString();
        }
    }
