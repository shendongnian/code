    #region MoveForm
    Point LastPoint;
    bool ShouldMove;
    private void form_MouseDown(object sender, MouseEventArgs e)
    {
        LastPoint = e.Location;
        ShouldMove = true;
        this.TransparencyKey = Color.FromArgb(111, 111, 111);
    }
    private void form_MouseUp(object sender, MouseEventArgs e)
    {
        ShouldMove = false;
    }
    private void form_MouseMove(object sender, MouseEventArgs e)
    {
        if (ShouldMove)
        {
            this.Location = new Point(
                 this.Location.X - LastPoint.X + e.X, 
                 this.Location.Y - LastPoint.Y + e.Y);
        }
    }
    #endregion
