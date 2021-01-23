    Point[] points = new Point[1];
    
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        int ptCount = points.Count();
        Array.Resize(ref points, ptCount + newPointAmt);
        
        
        // Add new points here.
        
        g.Clear(this.BackColor);
        g.DrawLines(new Pen(Color.White), points);
    }
