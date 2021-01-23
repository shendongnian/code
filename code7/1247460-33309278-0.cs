    app.Map("/Camera/Video", a =>
    {
    	a.Run(context =>
    	{
    		string connectionid = CurrentDevice.Value.ToString();
    		object ret = DeviceManager.Instance.SendMessageToDevice(connectionid, "startmovie");
    		context.Response.Headers.Add("Content-Type", new string[] { "multipart/x-mixed-replace; boundary=--jpgboundary" });
    
    		bool con = true;
    		StreamWriter writer = new StreamWriter(context.Response.Body);
    		while (con)
    		{
    			using (MemoryStream ms = new MemoryStream())
    			{
    				Image img = (Image)DeviceManager.Instance.SendMessageToDevice(connectionid, "capturestill");
    				img.Save(ms, ImageFormat.Jpeg);
    				byte[] buffer = ms.GetBuffer();
    
    				writer.WriteLine("--jpgboundary");
    				writer.WriteLine("Content-Type: image/jpeg");
    				writer.WriteLine(string.Format("Content-length: {0}", buffer.Length));
    				writer.WriteLine();
    				context.Response.Write(buffer);
    				//writer.WriteLine(Convert.ToBase64String(buffer));
    				writer.Flush();
    			}
    			Thread.Sleep(200);
    		}
    		DeviceManager.Instance.SendMessageToDevice(connectionid, "stopmovie");
    		return context.Response.WriteAsync("");
    	});
    });
