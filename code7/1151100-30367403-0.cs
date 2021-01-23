    public Ellipse() {
        MouseDown += shape_MouseDown;
        MouseMove += shape_MouseMove;
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Transparent;
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;
    }
