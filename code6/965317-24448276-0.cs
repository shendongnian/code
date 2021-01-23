    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                Color.Black, BORDER_SIZE, ButtonBorderStyle.Inset,
                                Color.Black, BORDER_SIZE, ButtonBorderStyle.Inset,
                                Color.Black, BORDER_SIZE, ButtonBorderStyle.Inset,
                                Color.Black, BORDER_SIZE, ButtonBorderStyle.Inset);
    } 
