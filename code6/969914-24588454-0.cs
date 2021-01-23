    public static uint ParseIP(string ip) {
      byte[] b = ip.Split('.').Select(s => Byte.Parse(s)).ToArray();
      if (BitConverter.IsLittleEndian) Array.Reverse(b);
      return BitConverter.ToUInt32(b, 0);
    }
    
    public static string FormatIP(uint ip) {
      byte[] b = BitConverter.GetBytes(ip);
      if (BitConverter.IsLittleEndian) Array.Reverse(b);
      return String.Join(".", b.Select(n => n.ToString()));
    }
