    private Image GetOvelappedImages(Image primaryImage, Image overlappingImage)
    {
     //create graphics from main image
     using (Graphics g = Graphics.FromImage(primaryImage))
     {
        //draw other image on top of main Image
         g.DrawImage(overlappingImage, new Point(0, 0));
     }
     return primaryImage;
    }
