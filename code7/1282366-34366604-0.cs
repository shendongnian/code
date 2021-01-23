    public class Image
    {
         public int ImageID { get; set; }
         public string DataType { get; set; }
         public int Size { get; set; }
         public byte[] Content { get; set; 
          
         public static Image SaveUpload(IFormFile formFile) {
            var newImage = new Image();
            var content = formFile.OpenReadStream();
            byte[] buf = new byte[content.Length];
            content.Read(buf, 0, buf.Length);
            var newImg = new Image();
            newImg.Content = buf;
            newImg.DataType = formFile.ContentType;
            return newImage;
        }
    }
