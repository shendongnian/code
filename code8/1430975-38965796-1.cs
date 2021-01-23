    Color pixelColour;
    private void myPicturebox_MouseClick(object sender, MouseEventArgs e)
    {
       if (e.Button == MouseButtons.Left) 
       {
         pixelColour = ((Bitmap)myPicturebox.Image).GetPixel(point.X, point.Y);
         if (this.BackColor == pixelColour)
         {
            // User clicked on transparent area
         }
         else
         {
            // User clicked on image
         }
       }
    }
    
