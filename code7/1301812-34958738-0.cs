	static string GetValidFileName(string data) 
	{
		var bytes = System.Text.Encoding.UTF8.GetBytes(@"W8D6m\2alNzPUW2d2m4V9EksLHg=");
		return Convert.ToBase64String(bytes).Replace("/", "_");
	}
