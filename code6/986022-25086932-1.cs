    using (Bitmap bmp = 
                  new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height))
    {
       pictureBox1.DrawToBitmap(bmp, pan_pictureBox1.ClientRectangle);
       bmp.Save(yourfilename.png);
    }
