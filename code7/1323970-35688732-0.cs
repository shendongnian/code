    TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
    Debug.Listeners.Add(writer);
    
    // PNG file contains 8 - bytes header.
    
    // JPEG file contains 2 - bytes header(SOI) followed by series of markers,
    // some markers can be followed by data array. Each type of marker has different header format.
    // The bytes where the image is stored follows SOF0 marker(10 - bytes length).
    // However, between JPEG header and SOF0 marker there can be other segments.
    
    // BMP file contains 14 - bytes header.
    
    // GIF file contains at least 14 bytes in its header.
    
    FileStream imageFile = new FileStream(@ "C:\\a.png", FileMode.Open);
    
    byte[] header = new byte[imageFile.Length];
    
    imageFile.Seek(0, SeekOrigin.Begin);
    imageFile.Read(header, 0, (int) imageFile.Length);
    
    
    var memStream = new MemoryStream(header);
    
    Image fileImage = Image.FromStream(memStream);
    
    //list image formats
    var imageFormats = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).ToList().ConvertAll(property => property.GetValue(null, null));
    System.Diagnostics.Debug.WriteLine(imageFormats.Count, "image_formats");
    
    foreach(var imageFormat in imageFormats) {
     // System.Diagnostics.Debug.WriteLine(imageFormat, "image_formats");
    }
    
    //get image format
    var fileImageFormat = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).ToList().ConvertAll(property => property.GetValue(null, null)).Single(image_format => image_format.Equals(fileImage.RawFormat));
    System.Diagnostics.Debug.WriteLine(fileImageFormat, "file_image_format");
    
    //list image codecs
    var imageCodecs = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders().ToList();
    System.Diagnostics.Debug.WriteLine(imageCodecs.Count, "image_codecs");
    foreach(var image_codec in imageCodecs) {
     //System.Diagnostics.Debug.WriteLine(image_codec.CodecName + ", mime: " + image_codec.MimeType + ", extension: " + @image_codec.FilenameExtension, "image_codecs");
    }
    
    //get image codec
    var fileImageFormatCodec = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders().ToList().Single(image_codec => image_codec.FormatID == fileImage.RawFormat.Guid);
    System.Diagnostics.Debug.WriteLine(fileImageFormatCodec.CodecName + ", mime: " + fileImageFormatCodec.MimeType + ", extension: " + fileImageFormatCodec.FilenameExtension, "image_codecs", "file_image_format_type");
