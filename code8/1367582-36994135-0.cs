	public static async Task CopyToWithProgressAsync(this Stream source,
                                                     Stream destination,
                                                     int bufferSize = 4096,
                                                     Action<long> progress = null)
	{
		var buffer = new byte[bufferSize];
		var total = 0L;
		int amtRead;
		do
		{
			amtRead = 0;
			while(amtRead < bufferSize)
			{
				var numBytes = await source.ReadAsync(buffer,
                                                      amtRead,
                                                      bufferSize - amtRead);
				if(numBytes == 0)
				{
					break;
				}
				amtRead += numBytes;
			}
			total += amtRead;
			await destination.WriteAsync(buffer, 0, amtRead);
			if(progress != null)
			{
				progress(total);
			}
		} while( amtRead == bufferSize );
	}
