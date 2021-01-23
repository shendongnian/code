    private void startToolStripMenuItem_Click(object sender, EventArgs e)
    {
        List<Point> points = new List<Point>();
        using (StreamReader sr = new StreamReader("../../sample.txt"))
        {
            string[] values = null;
            while ((zee1 = sr.ReadLine()) != null)
            {
                values = zee1.Split(',');
                points.Add(new Point(int.Parse(values[0]), int.Parse(values[2])));
            }
        }
        
        pictureBox1.Enabled = true;
        g = pictureBox1.CreateGraphics();
        for (int i = 0; i < points.Count - 1; i++)
            g.DrawLine(pen1, points[i], points[i+1]);
    }
