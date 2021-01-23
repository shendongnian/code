    byte[] logo = BmpToBytes_MemStream(Properties.Resources.gcs_logo);
    emailMessage.Attachments.AddFileAttachment("logo.jpg", logo);
    emailMessage.Attachments[emailMessage.Attachments.Count - 1].IsInline = true;
    emailMessage.Attachments[emailMessage.Attachments.Count - 1].ContentId = "gcs_logo.jpg";
    private static byte[] BmpToBytes_MemStream(Bitmap bmp)
    {
    	byte[] bmpBytes = null;
    	using (MemoryStream ms = new MemoryStream())
    	{
    		// Save to memory using the Jpeg format
    		bmp.Save(ms, ImageFormat.Jpeg);
    
    		// read to end
    		bmpBytes = ms.GetBuffer();
    		bmp.Dispose();
    	}
    
    	return bmpBytes;
    }
