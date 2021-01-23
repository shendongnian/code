    PointF realPosition = PointF.Empty; //Initialize it to the real position of the pb.
    private void timer_Tick(object sender, EventArgs e)
    {
        realPosition.Y += 1.0f * this.Height / 720.0f; //note the .0f to instruct the compiler these must be float operations
        nanas.Location = Point.Round(realPosition);
        nanas.Refresh();
    }
    
