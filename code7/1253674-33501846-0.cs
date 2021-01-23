    private void Circle(Graphics g)
    {
        Pen p1 = new Pen(Color.Black);
        g.DrawEllipse(p1, 12, 12, 50, 50);
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Graphics myg = e.Graphics;
        Circle(myg);
    }
