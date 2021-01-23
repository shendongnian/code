    PointF realPosition = PointF.Empty; //Initialize it to the real position of the pb.
    private void timer_Tick(object sender, EventArgs e)
    {
        realPosition.Y += 1.0 * this.Height / 720.0; //note the .0 to instruct the compiler these must be double operations
        nanas.Location = Point.Round(realPosition);
        nanas.Refresh();
    }
    
