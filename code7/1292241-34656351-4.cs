        using System.IO;
        ..
        byte[] iData = (byte[])dr[yourColumnIndexOrName];
        Bitmap bmp = null;
        if (iData != null)
           using (var ms = new MemoryStream(iData ))
           {
               bmp = new Bitmap(ms);
           } 
        pb_image.Image = bmp;  // display in a PictureBox
