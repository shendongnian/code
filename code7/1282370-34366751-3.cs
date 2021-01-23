    public class UploadService
    {
        public void SaveUpload(IFormFile formFile)
        {
            var content = formFile.OpenReadStream();
            byte[] buf = new byte[content.Length];
            content.Read(buf, 0, buf.Length);
            var newImg = new Image();
            newImg.Content = buf;
            newImg.DataType = formFile.ContentType;
            
            //insert newImg...
        }
    }
