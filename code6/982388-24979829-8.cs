    String strImageFile = Server.MapPath("/Images/FileName.jpg");
    System.Drawing.Size objMaxSize = new System.Drawing.Size(100, 100);
    System.Drawing.Bitmap objNewImage = SmartResize(strImageFile, objMaxSize);
    objNewImage.Save(Server.MapPath("/Images/FileName_Resized.jpg"));
    objNewImage.Dispose();
