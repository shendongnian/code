    private void Circle(PaintEventArgs e)
    {
        Graphics g1 = e.Graphics;
        Pen p1 = new Pen(Color.Black);
        g1.DrawEllipse(p1, 12, 12, 50, 50);
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Circle(e);
    }
