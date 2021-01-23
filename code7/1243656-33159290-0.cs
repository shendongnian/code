    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawRectangle(Pens.Red, new Rectangle(10, 10, 100, 100));
    }
    private void button1_Click(object sender, EventArgs e)
    {
        this.printDocument1.Print();
    }
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        var bmp=new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
        this.pictureBox1.DrawToBitmap(bmp,this.pictureBox1.ClientRectangle);
        e.Graphics.DrawImageUnscaled(bmp, 0, 0);
    }
