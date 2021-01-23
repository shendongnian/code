     // a Rectangle for testing
     Rectangle rectCropArea = new Rectangle(22,22,55,99);
     Bitmap sourceBitmap = 
            new Bitmap(SrcPicBox.Image, SrcPicBox.Image.Width, SrcPicBox.Image.Height);  //*
       
     using ( Graphics g = Graphics.FromImage(sourceBitmap) )
         g.DrawImage(sourceBitmap, TargetPicBox.ClientRectangle,
                     rectCropArea, GraphicsUnit.Pixel);
     TargetPicBox.Image = sourceBitmap;
