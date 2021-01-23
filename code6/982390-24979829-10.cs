       String strImageFile = Server.MapPath("/Images/ImageFile.jpg");
       System.Drawing.Bitmap objImage = new System.Drawing.Bitmap(strImageFile);
       System.Drawing.Size objNewSize = new System.Drawing.Size(100, 50);
       System.Drawing.Bitmap objNewImage = Resize(objImage, objNewSize, ImageFormat.Jpeg);
       objNewImage.Save(Server.MapPath("/Images/FileName_Resized.jpg"), ImageFormat.Jpeg);
       objNewImage.Dispose();
