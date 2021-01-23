    using (var ms = new MemoryStream())
    {
    	image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
    	var imageArr = ms.ToArray();
    	using (var stream = req.GetRequestStream())
    	{
    		stream.Write(imageArr, 0, imageArr.Length);
    	}
    }
