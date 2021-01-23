    Bitmap GraphBackground = null;
    Bitmap GraphImage = null;
    Point aPoint = Point.Empty;
    private void Form1_Load(object sender, EventArgs e)
    {
        PictureBox Graph = pictureBox1;  // short reference, optional
        GraphBackground = new Bitmap(Graph.ClientSize.Width, Graph.ClientSize.Height);
        GraphImage = new Bitmap(Graph.ClientSize.Width, Graph.ClientSize.Height);
        // intial set up, repeat as needed!
        Graph.BackgroundImage = DrawBackground(GraphBackground);
        Graph.Image = DrawGraph(GraphImage);
    }
    Bitmap DrawBackground(Bitmap bmp)
    {
        using (Graphics G = Graphics.FromImage(bmp) )
        {
            // my little axis code..
            Point c = new Point(bmp.Width / 2, bmp.Height / 2);
            G.DrawLine(Pens.DarkSlateGray, 0, c.Y, bmp.Width, c.Y);
            G.DrawLine(Pens.DarkSlateGray, c.X, 0, c.X, bmp.Height);
            G.DrawString("0", Font, Brushes.Black, c);
        }
        return bmp;
    }
    Bitmap DrawGraph(Bitmap bmp)
    {
        using (Graphics G = Graphics.FromImage(bmp))
        {
            // do your drawing here
            
        }
        return bmp;
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        // make it as fat as you like ;-)
        e.Graphics.FillEllipse(Brushes.Red, aPoint.X - 3, aPoint.Y - 3, 7, 7);
    }
