	public static void ReadSplitWrite(string inputFile, string outputFile)
	{
		using (var sr = File.OpenRead(inputFile))
		using (var sw = File.Create(outputFile))
		{
			int read;
			byte[] inputBuffer = new byte[4096];
			byte[] outputBuffer = new byte[inputBuffer.Length * 2];
			while ((read = sr.Read(inputBuffer, 0, inputBuffer.Length)) != 0)
			{
				for (int i = 0, j = 0; i < read; i++, j += 2)
				{
					outputBuffer[j] = (byte)(inputBuffer[i] & 0x0F);
					outputBuffer[j + 1] = (byte)(inputBuffer[i] & 0xF0);
				}
				sw.Write(outputBuffer, 0, read * 2);
			}
		}
	}
	public static void ReadMergeWrite(string inputFile, string outputFile)
	{
		using (var sr = File.OpenRead(inputFile))
		using (var sw = File.Create(outputFile))
		{
			int read;
			byte[] inputBuffer = new byte[4096 * 2];
			byte[] outputBuffer = new byte[inputBuffer.Length / 2];
			while ((read = sr.Read(inputBuffer, 0, inputBuffer.Length)) != 0)
			{
				for (int i = 0, j = 0; i < read; i += 2, j++)
				{
					outputBuffer[j] = inputBuffer[i];
					outputBuffer[j] |= inputBuffer[i + 1];
				}
				sw.Write(outputBuffer, 0, read / 2);
			}
		}
	}
