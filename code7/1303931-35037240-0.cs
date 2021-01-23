    var client = new HttpClient();
    var response = await client.GetAsync(new Uri($"{url}{imageId}")); // call to WebApi; url and imageId defined earlier
    
    if (response.IsSuccessStatusCode)
    {
        using (var contentStream = await response.Content.ReadAsInputStreamAsync())
        {
            var stream = contentStream.AsStreamForRead();
            var file = await imagesFolder.CreateFileAsync(imageFileName, CreationCollisionOption.ReplaceExisting);
    		
    		using (MemoryStream ms = new MemoryStream())
    		{
    			await stream.CopyToAsync(ms);
    			using (var fileStream = await file.OpenStreamForWriteAsync())
    			{
    				ms.Seek(0, SeekOrigin.Begin);
    				await ms.CopyToAsync(fileStream);
    				ms.Seek(0, SeekOrigin.Begin); // rewind for next use below
    			}
    
    			string md5Hash = await Utils.GetMD5Hash(ms);
    			await AddImageToDataBase(file, md5Hash);
    		}
        }
    }
