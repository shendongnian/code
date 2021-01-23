	using (var writer = new DataWriter(device.OutputStream))
	{
		writer.WriteString("W\r\n");
		using (var cts = new CancellationTokenSource(device.WriteTimeout))
		{
			await writer.StoreAsync().AsTask(cts.Token);
		}
		writer.DetachStream();
	}
	using (var reader = new DataReader(device.InputStream))
	{
		using (var cts = new CancellationTokenSource(device.ReadTimeout))
		{
			var read = await reader.LoadAsync(12).AsTask(cts.Token);
			if (read >= 12)
			{
				var data = reader.ReadString(12);
				reader.DetachStream();
				return ExtractWeightChangedEventArgs(data);
			}
		}
	}
