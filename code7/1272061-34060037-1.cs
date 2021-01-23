    var imageIn = System.Drawing.Image.FromFile(@"C:\Users\User\Desktop\sample-profile-image.jpeg");
    byte[] bytes;
    using (var ms = new MemoryStream())
    {
    	imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    	bytes = ms.ToArray();	
    }
    
    using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
    {
    	System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
    	image.Save(@"D:\Images\Photo.jpg");
    }
