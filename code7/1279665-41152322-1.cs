    // includes BitmapEncoder, which defines some static encoder IDs
    using Windows.Graphics.Imaging;
    
    
    private async void PlayWithData(SoftwareBitmap softwareBitmap)
	{
        // get encoded jpeg bytes
		var data = await EncodedBytes(softwareBitmap, BitmapEncoder.JpegEncoderId);
    
		// todo: save the bytes to a DB, etc
	}
    private async Task<byte[]> EncodedBytes(SoftwareBitmap soft, Guid encoderId)
	{
		byte[] array = null;
        
        // First: Use an encoder to copy from SoftwareBitmap to an in-mem stream (FlushAsync)
        // Next:  Use ReadAsync on the in-mem stream to get byte[] array
		
        using (var ms = new InMemoryRandomAccessStream())
		{
			BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, ms);
			encoder.SetSoftwareBitmap(soft);
			try
			{
				await encoder.FlushAsync();
			}
			catch ( Exception ex ){ return new byte[0]; }
			array = new byte[ms.Size];
			await ms.ReadAsync(array.AsBuffer(), (uint)ms.Size, InputStreamOptions.None);
		}
		return array;
	}
