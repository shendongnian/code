    private List<Point> points = new List<Point>();
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        points.Add(e.Location);
    }
