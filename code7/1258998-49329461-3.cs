        private AlternateView GetEmbeddedImage(Dictionary<string, Byte[][]> streamAttachment, string msgTemplate, string fileFormat)
        {
            LinkedResource imageFile = null;
            AlternateView alternateView = null;
            string msgBody = string.Empty;
            try
            {
        	List<LinkedResource> imageFiles = new List<LinkedResource>();
        	for (int page = 0; page < streamAttachment[fileFormat].Length; page++)
        	{   
            		imageFile = new LinkedResource(new MemoryStream(streamAttachment[fileFormat][page]));
            		imageFile.ContentId = Guid.NewGuid().ToString();
            		msgBody = msgBody + "<BR/>" + string.Format(msgTemplate, imageFile.ContentId);
            		imageFiles.Add(imageFile); 
        	}
         
        	alternateView = AlternateView.CreateAlternateViewFromString(msgBody, null, MediaTypeNames.Text.Html);
        	imageFiles.ForEach(img => alternateView.LinkedResources.Add(img));
            }
            catch (Exception Ex)
            {
        
            }
            return alternateView;
        } 
