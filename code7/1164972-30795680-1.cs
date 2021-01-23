	string str = "aquí";
	StringBuilder output = new StringBuilder();
	for (int i = 0; i < str.Length; i++)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(str.Substring(i, 1));
		if (bytes.Length == 1 && bytes[0] < 128)
		{
			output.Append(str[i]);
		}
		else
		{
			foreach (byte b in bytes)
			{
				output.Append(@"\" + Convert.ToString(b, 8));
			}
		}
	}
    string result = output.ToString();
