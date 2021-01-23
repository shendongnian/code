    private int _angle = 0;
    private Point _location = new Point(0, 0);
    private void _timer_Tick(object sender, System.EventArgs e)
    {
        // nothing interesting here, moving the top left co-ordinate of the         
        // rectangle at constant rate
        _location = new System.Drawing.Point(_location.X + 2, _location.Y + 2);
        _angle += 5; // our current rotation angle
        this.Invalidate();
    }
    
    void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;            
        // rebase the co-ordinate system so our current x,y is 0, 0 and that is   
        // the center of the rotation
        g.TranslateTransform(_location.X, _location.Y, MatrixOrder.Append);
        g.RotateTransform(_angle); // do the rotation
        // make sure the centre of the rectangle is the centre of rotation (0, 0)
        g.FillRectangle(new SolidBrush(Color.Red), -5, -5, 10, 10);
    }
