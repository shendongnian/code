		var requests = new Task[parts.Count];
        foreach (var part in parts)
        {
            var partNumber = part.Item1;
            var partSize = part.Item2;
            requests[partNumber - 1] = UploadPartAsync(partNumber, partSize);
        }
        await Task.WhenAll(requests);
		
    ...
		
	async Task UploadPartAsync(int partNumber, int partSize)
	{
		using (var ms = new MemoryStream(partSize))
		using (var bw = new BinaryWriter(ms))
		{
			var offset = (partNumber - 1) * partMaxSize;
			var count = partSize;
			bw.Write(assetContentBytes, offset, count);
			ms.Position = 0;
			Console.WriteLine("beginning upload of part " + partNumber);
			await uploadClient.UploadPart(uploadResult.AssetId, partNumber, ms);
		}
	}
