    private List<Point> pts =  new List<Point>();
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        var mouseEventArgs = e as MouseEventArgs;
        Point rp = new Point(mouseEventArgs.X, mouseEventArgs.Y);
        pts.Add(rp);    
    }
    public void button2_Click(object sender, EventArgs e)
    {
        File.AppendAllLines("new.txt", pts.Select(p => p.ToString()));
        pts.Clear();
    }
