    // Add a new csharp file to your project
    // Add below code to it
    public static class DrawingExtensions
    {
        public static string ConvertToBase64ImageFormat ( this byte[] b, ImageFormats f)
        {
                // you can find other formats image mimeType and add all you need
               string mt = system.Net.Mime.MediaTypeNames.Image.Tiff;
               string i = Convert.ToBase64String(b);
               return string.Format("data:{0};base64,{1}",mt,i);
        }
    }
    public enum  ImageFormats
    {
         Jpeg
         Png ,
         // And other formats
    }
