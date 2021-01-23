    uint test = 0x1047F71;
    var bytes = BitConverter.GetBytes(test);
    if (BitConverter.IsLittleEndian)
        bytes = bytes.Reverse().ToArray();
    // now bytes[] are big-endian no matter what system the code is running on.
