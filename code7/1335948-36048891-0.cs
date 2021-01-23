	byte[] salt = new byte[] {67,79,79,76};
	Console.WriteLine(salt.ToString()); // prints System.Byte[]
		
	string saltAsString = System.Text.Encoding.Default.GetString(salt);
	Console.WriteLine(saltAsString); // prints COOL
