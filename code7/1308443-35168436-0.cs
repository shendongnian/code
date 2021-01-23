	_NumbersInMemory =
		File
			.ReadAllLines(@"path")
			.Select(line => line.Trim())
			.Select(line =>
			{
				int numberInMemoryTemporarily = 0;
	            if (int.TryParse(line, out numberInMemoryTemporarily))
				{
					return numberInMemoryTemporarily;
				}
				return 0;
			})
			.ToArray();
