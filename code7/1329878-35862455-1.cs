    class SelectionBox : Panel
    {
    	public SelectionBox()
    	{
    		ResizeRedraw = true;
    		DoubleBuffered = true;
    	}
    	protected override void OnPaint(PaintEventArgs e)
    	{
    		base.OnPaint(e);
    		ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
    	}
    }
