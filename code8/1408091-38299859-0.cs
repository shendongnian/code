	Console.WriteLine("Saxon:");
	for (int i = 0; i < 3; i++)
	{
		sw.Reset();
		sw.Start();
		Parallel.ForEach(files, file =>
		{
			string target = Path.Combine(output, Path.GetFileName(file));
			XsltTransformer transformer = executable.Load();
			XdmNode input = null;
			using (XmlReader xr = XmlReader.Create(file, readerSettings))
				input = docBuilder.Build(xr);
			transformer.InitialContextNode = input;
			Serializer serializer = new Serializer();
			serializer.SetOutputFile(target);
			transformer.Run(serializer);
		});
		sw.Stop();
		Console.WriteLine("Duration: " + sw.Elapsed);
		RemoveFiles(output);
	}
