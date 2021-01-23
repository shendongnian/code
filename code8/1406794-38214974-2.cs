    var process = Process.GetProcessById(844); // found pid manually
    var image = Icon.ExtractAssociatedIcon(process.MainModule.FileName).ToBitmap();
    pb1.Image = image;
    
    byte[] imageBytes; 
               
    using (var ms = new MemoryStream())
    { 
        image.Save(ms, ImageFormat.Png);        // PNG for transparency
        ms.Position = 0;
        pb2.Image = (Bitmap)Image.FromStream(ms);                
    }
