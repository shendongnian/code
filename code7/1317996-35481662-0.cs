    public Result UploadUserProfilePicture(Stream image)
    {
        try
        {
            // Store bytes in a variable
            var bytes = CommonMethods.ReadToEnd(image);
            FileType fileType = bytes.GetFileType();
            Guid guid = Guid.NewGuid();
            string imageName = guid.ToString() + "." + fileType.Extension;
            var path = Path.Combine(@"C:\" + imageName);
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
