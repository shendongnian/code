    public Result UploadUserProfilePicture(FileToUpload image)
    	{
    		try
    		{
    			byte[] bytes = Convert.FromBase64String(image.File);
    
    			FileType fileType = bytes.GetFileType();
    			
    			Guid guid = Guid.NewGuid();
    			string imageName = guid.ToString() + "." + fileType.Extension;
    			var path = Path.Combine(@"C:\UploadedImages\" + imageName);
    
    			File.WriteAllBytes(path, bytes);
    
    			return new Result
    			{
    				Success = true,
    				Message = imageName
    			};
    		}
    		catch(Exception ex)
    		{
    			return new Result
    			{
    				Success = false,
    				Message = ex.ToString()
    			};
    		}
    	}
