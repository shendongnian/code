    byte[] buf = new byte[] { 0xF0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
    var bytesFromBits = BytesToBooleans(buf)
        .BooleansAsBitsFromLowest();
    foreach (var resultingByte in bytesFromBits)
    {
        Console.WriteLine(resultingByte.ToString("X2"));
    }
