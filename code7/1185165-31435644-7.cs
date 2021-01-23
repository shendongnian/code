    string SaveImage (MimePart image, string url)
    {
        using (var output = new MemoryStream ()) {
            image.ContentObject.DecodeTo (output);
    
            var buffer = output.GetBuffer ();
            int length = (int) output.Length;
    
            return string.Format ("data:{0};base64,{1}", image.ContentType.MimeType, Convert.ToBase64String (buffer, 0, length));
        }
    }
