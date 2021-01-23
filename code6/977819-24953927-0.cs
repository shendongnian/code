		// returned from www.bytes, copied here for readability
		byte[] bytes=new byte[]{116, 101, 120, 116, 105, 110, 101, 115, 115};
		string customDecoded=""; 
		foreach(var b in bytes)
			customDecoded+=(char)b; 
		Debug.Log(customDecoded); // textiness
		Debug.Log(System.Text.Encoding.Default); // System.Text.ASCIIEncoding
		Debug.Log(System.Text.Encoding.Default.GetString(bytes));  // textiness
		Debug.Log(System.Text.Encoding.ASCII.GetString(bytes));  // textiness
		Debug.Log(System.Text.Encoding.Unicode.GetString(bytes)); // 整瑸湩獥
		Debug.Log(System.Text.Encoding.UTF7.GetString(bytes)); // textiness
		Debug.Log(System.Text.Encoding.UTF8.GetString(bytes)); // textiness
		Debug.Log(System.Text.Encoding.UTF32.GetString(bytes)); // 整湩
		Debug.Log(System.Text.Encoding.BigEndianUnicode.GetString(bytes)); // 瑥硴楮敳
