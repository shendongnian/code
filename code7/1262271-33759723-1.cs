    class CustomControl : Control
    {
        public CustomControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    
        protected override void OnMouseMove(EventArgs e)
        {
            base.OnMouseMove(e);
            Refresh();
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics...;
        }
    }
