    byte[] bytes; //get from DB
    ...
    using (var ms = new System.IO.MemoryStream(bytes)) 
    {
        using(var img = Image.FromStream(ms)) 
        {
            var type = GetMimeType(img);
        }
    }
    
    public static string GetMimeType(Bitmap image)
    {
        var type = ImageCodecInfo.GetImageDecoders().FirstOrDefault(codec => codec.FormatID == image.RawFormat.Guid);
        return type != null ? type.MimeType : "image/unknown";
    }
