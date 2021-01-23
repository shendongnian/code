	var processInfo = new ProcessInfo(
		jpegOptimPath,
		"-m" + quality + " --strip-all --all-normal --stdin --stdout",
	);
	processInfo.CreateNoWindow = true;
	processInfo.WindowStyle = ProcessWindowStyle.Hidden;
	processInfo.UseShellExecute = false;
	processInfo.RedirectStandardInput = true;
	processInfo.RedirectStandardOutput = true;
	processInfo.RedirectStandardError = true;
	using(var process = new Process())
	{
		process.StartInfo = processInfo;
		process.Start();
		int chunkSize = 4096;	// Process has a limited 4096 byte buffer
		var buffer = new byte[chunkSize];
		int bufferLen = 0;
		var inputStream = process.StandardInput.BaseStream;
		var outputStream = process.StandardOutput.BaseStream;
		do
		{
			bufferLen = await input.ReadAsync(buffer, 0, chunkSize);
			await inputStream.WriteAsync(buffer, 0, chunkSize);
			inputStream.Flush();
		}
		while (bufferLen == chunkSize);
		do
		{
			bufferLen = await outputStream.ReadAsync(buffer, 0, chunkSize);
			if (bufferLen > 0)
				await output.WriteAsync(buffer, 0, bufferLen);
		}
		while (bufferLen > 0);
		while(!process.HasExited)
		{
			await Task.Delay(100);
		}
		output.Flush();
