	using (FileStream file = File.Create(path))
	{
		using (BinaryWriter writer = new BinaryWriter(file))
		{
			foreach (float value in samples32array)
			{
				writer.Write(value);
			}
		}
	}
