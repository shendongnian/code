    1.
    byte[] img = Convert.FromBase64String(s);
    System.IO.File.WriteAllBytes(@"C:\image.bmp", img);
     
    2.
    ImageConverter img_converter = new ImageConverter();
    byte[] bytes = (byte[])img_converter.ConvertTo(<strong class="highlight">image</strong>, typeof(byte[]));  
    File.WriteAllBytes(savefil.FileName, bytes);
     
    3.
    var imageBytes = File.ReadAllBytes("bitmap.bmp");
    var image = imageBytes.ToImage();
    image.Save("output.bmp");
    
    4.1 from some file:
    Image.Save(@"FilePath", ImageFormat.Jpeg);
    
     
    4.2.
    Image bitmap = Image.FromFile("C:\\MyFile.bmp");
    bitmap.Save("C:\\MyFile2.bmp");  
     
    5. from pictureBox:
    pictureBox1.Image.Save(@"path + imageName",ImageFormat.Jpeg);
