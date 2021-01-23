    using (var client = new SftpClient(ftpUploadPath, ftpPort, ftpUser, ftpPassword))
    {
        client.Connect();
        using (var stream = new MemoryStream())
        {
    		client.DownloadFile(fileName, stream);
    		using (var img = Image.FromStream(stream, true))
    		{
    			img.RotateFlip(RotateFlipType.Rotate90FlipNone);
    			
    			using (var newStream = new MemoryStream())
    			{
    				img.Save(newStream, ImageFormat.Jpeg);
    				newStream.Position = 0;
    				client.UploadFile(newStream, item);
    			}
    		}
    	}
    }
