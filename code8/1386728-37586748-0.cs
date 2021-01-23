    private bool _buttonClicked = _false;
    
    void myButton_Click(object sender, EventArgs e)
    {
       _buttonClicked = true;
       this.Invalidate(); // <-- invalidate the form so it's repainted
       this.Update(); // <-- optional: force a synchronous repaint
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if(!_buttonClicked) return;
        // this will only happen after button is clicked
        var cp = new Point(Width / 2, Height / 2);
        DrawGradientCircle(e.Graphics, cp, 100);
    }
