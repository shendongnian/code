    private Bitmap CropImage(){
        Bitmap pic = pictureBoxSnap.Image as Bitmap;
        Bitmap cropped = new Bitmap(rect.Width, rect.Height);
        using (Graphics g = Graphics.FromImage(cropped)){
            g.DrawImage(pic, new Rectangle(0, 0, rect.Width, rect.Height),
                             rect, GraphicsUnit.Pixel);
        }
        using (Graphics g = Graphics.FromImage(pic)){
            g.DrawImage(cropped , 136, 149, rect.Width, rect.Height);
            //Draw the rectangle
        }
        //pic.Save(@"c:\temp\testingitimage.jpg");
        //cropped.Save(@"c:\temp\testingitimage1.bmp");
        return pic;
    }
