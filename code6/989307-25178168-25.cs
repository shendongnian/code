    var bytes = new byte[50];
    
    using (var stream = new FileStream("filepath...", FileMode.Open))
    {
        stream.Read(bytes, 0, 50);
    }
    var speakerMask = BitConverter.ToUInt32(new[] { bytes[40], bytes[41], bytes[42], bytes[43] }, 0);
