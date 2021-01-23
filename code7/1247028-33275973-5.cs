    public string EncryptString(string aString)
	{
		StringBuilder sb = new StringBuilder();
		var enc = Encoding.GetEncoding("windows-1252");
		for (var i = 0; i < aString.Length; i++)
		{
			var x = enc.GetBytes(aString.Substring(i, 1))[0] - 1;
			var y = enc.GetBytes((i + 1).ToString())[0] + x;
			byte[] b = {y};
			sb.Append(enc.GetString(b));
		}
		return sb.ToString();
	}
