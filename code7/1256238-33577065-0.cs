    bool drawBorder = false;
    private void button1_Click(object sender, EventArgs e)
    {
        printPreviewDialog1.Document = printDocument1;
        drawBorder = true;
        printPreviewDialog1.ShowDialog();
        drawBorder = false;
    }
    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        var bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
        this.pictureBox1.DrawToBitmap(bmp, this.pictureBox1.ClientRectangle);
        if (drawBorder) {
          e.Graphics.DrawRectangle(Pens.Salmon, 25, 25, 500, 1000);
        }
        e.Graphics.DrawImage(bmp, 25, 25, 500, 500); //Gets the input from the textboxes
    }
