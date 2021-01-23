	byte[,] bytes = new byte[,] { 
		{ (byte)'H', (byte)'e', (byte)'l', (byte)'l', (byte)'o', (byte)'!' },
		{ (byte)'W', (byte)'o', (byte)'r', (byte)'l', (byte)'d', (byte)0 }
	};
	string[] strings = new string[bytes.GetLength(0)];
	for(var i = 0; i < bytes.GetLength(0); i++) {
		byte[] stringBytes = bytes.OfType<byte>()
			.Skip(i * bytes.GetLength(1))
			.Take(bytes.GetLength(1))
			.ToArray();
		strings[i] = System.Text.Encoding.UTF8.GetString(stringBytes);
	}
