    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        var bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
        this.pictureBox1.DrawToBitmap(bmp, this.pictureBox1.ClientRectangle);
        if (this.printDocument1.PrintController.IsPreview) {
          e.Graphics.DrawRectangle(Pens.Salmon, 25, 25, 500, 1000);
        }
        e.Graphics.DrawImage(bmp, 25, 25, 500, 500); //Gets the input from the textboxes
    }
