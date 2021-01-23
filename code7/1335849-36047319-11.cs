    List<Point> currentPoints = new List<Point>();
    List<List<Point>> allPointLists = new List<List<Point>>();
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        currentPoints = new List<Point>();
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        if (currentPoints.Count > 1)
        {
            allPointLists.Add(currentPoints.ToList());
            currentPoints.Clear();
        }
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            currentPoints.Add(e.Location);
            Invalidate();
        }
    }
