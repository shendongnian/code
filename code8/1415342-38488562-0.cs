    private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
    e.Graphics.DrawString("Hello GDI+ World!",
    new Font("Verdana", 16),
    new SolidBrush(Color.Red),
    new Point(20, 20));
    }
