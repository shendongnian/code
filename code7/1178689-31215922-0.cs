    private static string xor(string text, string key) {
		var result = new StringBuilder();
		for (int c = 0; c < text.Length; c++)
		  result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));
		return result.ToString();
	}
    string text = "my_xor_hash";
	string key = "my_xor_key";
	string encrypt = xor(text, key);
	string decrypt = xor(encrypt, key);
	System.Console.Write("Encrypt " + encrypt);
	System.Console.Write("Decrypt " + decrypt);
