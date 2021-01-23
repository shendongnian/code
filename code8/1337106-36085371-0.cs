		IPAddress ip = IPAddress.Parse("192.168.232.189");
		Console.WriteLine(ByteArrayToString(ip.GetAddressBytes()));	
	public static string ByteArrayToString(byte[] ba)
	{
	  string hex = BitConverter.ToString(ba);
	  return hex.Replace("-","");
	}
