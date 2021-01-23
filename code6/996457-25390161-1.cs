    Graphics g;
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        SolidBrush brush = new SolidBrush(Color.Black);
        this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        this.g.FillEllipse(brush, e.X, e.Y, 5, 5);
        pictureBox1.Refresh();
    }
    private void Form1_Shown(object sender, EventArgs e)
    {
        this.g = Graphics.FromImage(pictureBox1.Image);
        buffer = new Bitmap(pictureBox1.Image);
        bufferGraphics = Graphics.FromImage(buffer);
    }
    Image buffer;
    Graphics bufferGraphics;
    private void button1_Click(object sender, EventArgs e)
    {
        bufferGraphics.DrawImage(pictureBox1.Image,0,0);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        this.g.Clear(Color.Transparent);
        this.g.DrawImage(this.buffer, 0, 0);
        pictureBox1.Refresh();
    }
