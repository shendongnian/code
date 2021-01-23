     // a Rectangle for testing
     Rectangle rectCropArea = new Rectangle(22,22,55,99);
     // see the note below about the aspect ratios of the two rectangles!!
     Rectangle targetRect = TargetPicBox.ClientRectangle;
     Bitmap targetBitmap = new Bitmap(targetRect.Width, targetRect.Height);
     using (Bitmap sourceBitmap = new Bitmap(SrcPicBox.Image,
                                  SrcPicBox.Image.Width, SrcPicBox.Image.Height) )
     using (Graphics g = Graphics.FromImage(targetBitmap))
            g.DrawImage(sourceBitmap, targetRect, rectCropArea, GraphicsUnit.Pixel);
     if (TargetPicBox.Image != null) TargetPicBox.Dispose();
     TargetPicBox.Image = targetBitmap;
