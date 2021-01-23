    req.ContentType = "multipart/form-data";
    using (var ms = new MemoryStream())
    {
    	image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); //if it is jpeg
    	string encoded = Convert.ToBase64String(ms.ToArray());
    	byte[] reqData = Encoding.UTF8.GetBytes(encoded);
    	using (var stream = req.GetRequestStream())
    	{
    		stream.Write(reqData, 0, reqData.Length);
    	}
    }
