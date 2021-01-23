      public class AddCandidateProfilePictureCommand:     
                                           IAddCandidateProfilePictureCommand
           {
            public AddCandidateProfilePictureResponse Execute(HttpPostedFile 
           postedFile)
            {
                byte[] fileBytes;
        
                using (var memoryStream = new MemoryStream())
                {
                    postedFile.InputStream.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
        
                if (ImageWriterHelper.GetImageFormat(fileBytes) == 
                    ImageWriterHelper.ImageFormat.Unknown)
                    throw new BadImageFormatException();
        
                var extension = Path.GetExtension(postedFile.FileName);
                var tempCandidateImageName = Guid.NewGuid();
                var fileName = $"{tempCandidateImageName}{extension}";
                var fileUrl =              
        WebConfigurationManager.AppSettings["CandidateProfilePictureAddress"];
                var filePath = Path.Combine(fileUrl, fileName);
        
                if (!Directory.Exists(fileUrl))
                    Directory.CreateDirectory(fileUrl);
        
                postedFile.SaveAfterResizeImage(filePath, extension);
        
                return new AddCandidateProfilePictureResponse { 
                          TempCandidateImageName = fileName };
            }
            }
        
         
