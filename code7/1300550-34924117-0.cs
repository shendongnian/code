    double d = 12.34;	
	var bytes = BitConverter.GetBytes(d);
	StringBuilder sb = new StringBuilder();
	foreach (var b in bytes)
	{
		sb.Append(b.ToString("X2"));
	}
	sb.Dump();
