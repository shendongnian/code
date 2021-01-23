    String strImageFile = Server.MapPath("/Images/ImageFile.png");
    System.Drawing.Size objMaxSize = new System.Drawing.Size(100, 100);
    System.Drawing.Bitmap objNewImage = SmartResize(strImageFile, objMaxSize, ImageFormat.Png);
    objNewImage.Save(Server.MapPath("/Images/FileName_Resized.png"), ImageFormat.Png);
    objNewImage.Dispose();
