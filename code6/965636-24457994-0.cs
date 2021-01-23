    DirectoryInfo d = new DirectoryInfo(@"D:\Data\lzwtest");
    FileInfo[] Files = d.GetFiles("*.tif");
    foreach (FileInfo file in Files)
    {
        using(MemoryStream ms = new MemoryStream(File.ReadAllBytes(file))) 
        {
            Bitmap image1 = (Bitmap)Image.FromStream(ms);
            int tiffpages = image1.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            if (tiffpages == 1)
            {
                 image1.Save(@"D:\Data\lzwtest\" + file.Name, myImageCodecInfo, myEncoderParameters);
            }
        }
    }
    
