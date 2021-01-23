    private List<Point> pts =  new List<Point>();
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        Point rp = new Point(e.X, e.Y);
        pts.Add(rp);    
    }
    public void button2_Click(object sender, EventArgs e)
    {
        File.AppendAllLines("new.txt", pts.Select(p => p.ToString()));
        // OR
        // File.AppendAllLines("new.txt", pts.Select(p => "X= " + p.X + " Y= " + p.Y));
        pts.Clear();
    }
