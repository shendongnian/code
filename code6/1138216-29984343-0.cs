     // a Rectangle for testing
     Rectangle rectCropArea = new Rectangle(22,22,55,99);
     Bitmap sourceBitmap = new Bitmap(SrcPicBox.Image, SrcPicBox.Width, SrcPicBox.Height);
       
     using ( Graphics g = Graphics.FromImage(sourceBitmap) )
         g.DrawImage(sourceBitmap, 
                     new Rectangle(0, 0, TargetPicBox.Width, TargetPicBox.Height),
                     rectCropArea, GraphicsUnit.Pixel);
     TargetPicBox.Image = sourceBitmap;
