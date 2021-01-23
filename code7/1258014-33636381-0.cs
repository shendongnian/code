    private void croptoSquare(string date)
    {
        //Location of 320x240 image
        string fileName = Server.MapPath("~/Content/images/" + date + "contactimage.jpg");
        
        // Create a new image at the cropped size
        Bitmap cropped = new Bitmap(240,240);
        
        //Load image from file
        using (Image image = Image.FromFile(fileName))
        {
            // Create a Graphics object to do the drawing, *with the new bitmap as the target*
            using (Graphics g = Graphics.FromImage(cropped) )
            {
                // Draw the desired area of the original into the graphics object
                g.DrawImage(image, new Rectangle(0, 0, 240, 240), new Rectangle(40, 0, 240, 240), GraphicsUnit.Pixel);
                fileName = Server.MapPath("~/Content/images/" + date + "contactimagecropped.jpg");
                // Save the result
                cropped.Save(fileName);  
            }
         }
        
    }
