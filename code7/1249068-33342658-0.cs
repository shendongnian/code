            public static class RequestMessageExtensions
        {
            internal static byte[] GetContent(this HttpRequestMessage request)
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile("..\\..\\Images\\UploadFileTest.jpg");
    
            var converter = new System.Drawing.ImageConverter();
            byte[] byteContent = (byte[]) converter.ConvertTo(image,typeof(byte[]));
            var content = new ByteArrayContent(byteContent);
            content.Headers.Add("Content-Disposition", "form-data");
    
    return content;
            }
      }
