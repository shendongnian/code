    TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
    Debug.Listeners.Add(writer);
    
    // PNG file contains 8 - bytes header.
    
    // JPEG file contains 2 - bytes header(SOI) followed by series of markers,
    // some markers can be followed by data array. Each type of marker has different header format.
    // The bytes where the image is stored follows SOF0 marker(10 - bytes length).
    // However, between JPEG header and SOF0 marker there can be other segments.
    
    // BMP file contains 14 - bytes header.
    
    // GIF file contains at least 14 bytes in its header.
    
    FileStream memStream = new FileStream(@"C:\\a.png", FileMode.Open);
    
    Image fileImage = Image.FromStream(memStream);
        
    //get image format
    var fileImageFormat = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).ToList().ConvertAll(property => property.GetValue(null, null)).Single(image_format => image_format.Equals(fileImage.RawFormat));
    MessageBox.Show("File Format: " + fileImageFormat);
    
    
    //get image codec
    var fileImageFormatCodec = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders().ToList().Single(image_codec => image_codec.FormatID == fileImage.RawFormat.Guid);
    MessageBox.Show("MimeType: " + fileImageFormatCodec.MimeType + " \n" + "Extension: " + fileImageFormatCodec.FilenameExtension + "\n" + "Actual Codec: " + fileImageFormatCodec.CodecName);
