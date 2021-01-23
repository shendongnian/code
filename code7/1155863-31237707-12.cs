    // UTF-8 with BOM.
    var encoding = new UTF8Encoding(true);
    // Buffer encoded as UTF-8 with BOM.
    byte[] buff = encoding.GetPreamble()
        .Concat(encoding.GetBytes(message))
        .ToArray();
    
    // Size of the encoded buffer.
    byte size = Convert.ToByte(buff.Length);
    ns.WriteByte(size);
    ns.Write(buff, 0, buff.Length);
    ns.Flush();
