    private PictureBox _thePicture;
    public PictureBox ThePicture
    {
        set { this._thePicture = value; }
        get { return this._thePicture; }
    }
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
       if (this.ThePicture != null)
       {
           var bmp = new Bitmap(this.ThePicture.Width, this.ThePicture.Height);
           this.ThePicture.DrawToBitmap(bmp, this.ThePicture.ClientRectangle);
           e.Graphics.DrawImage(bmp, 25, 25, 800, 1050);
       }
    }
