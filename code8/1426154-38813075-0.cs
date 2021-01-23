	.Select(f => {
		using (var fs = new FileStream(f, FileMode.Open, FileAccess.Read))
		{
			return new
			{
				FileName = f,
				FileHash = BitConverter.ToString(new SHA1Managed().ComputeHash(fs))
			});
		}
	)
	
