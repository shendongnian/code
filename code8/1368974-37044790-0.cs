    string hex = "A3";
    byte packet1 = (byte)(int.Parse(hex[0].ToString(), NumberStyles.HexNumber) + 0x30);
    byte packet2 = (byte)(int.Parse(hex[1].ToString(), NumberStyles.HexNumber) + 0x30);
    
    Console.WriteLine("{0:X2}, {1:X2}", packet1, packet2); // 3A, 33
