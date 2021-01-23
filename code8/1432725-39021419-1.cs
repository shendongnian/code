    Bitmap image;
    private void DrawImage(Bitmap image, Graphics g, Rectangle r)
    {
        using (var brush = new TextureBrush(image))
        {
            brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            g.FillRectangle(brush, r);
        }
    }        
    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            using (var s = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open))
                image = new Bitmap(Image.FromStream(s));
            this.Invalidate();
        }
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (image != null)
            this.DrawImage(image, e.Graphics, new RectangleF(10, 10, 200, 200));
    }
