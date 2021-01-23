	Console.WriteLine("XslCompiledTransform:");
	for (int i = 0; i < 3; i++)
	{
		sw.Reset();
		sw.Start();
		Parallel.ForEach(files, file =>
		{
			string target = Path.Combine(output, Path.GetFileName(file));
			using (XmlReader xr = XmlReader.Create(file, readerSettings))
			using (XmlWriter xw = XmlWriter.Create(target, writerSettings))
				xslt.Transform(xr, xw);
		});
		sw.Stop();
		Console.WriteLine("Duration: " + sw.Elapsed);
		RemoveFiles(output);
	}
