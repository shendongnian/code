    public Main()
    {
            InitializeComponent();
    
            // Redraw gripper on resize
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            // Ability to minimize/restore the form with animation
            this.FormBorderStyle = FormBorderStyle.Sizable;
    }
    // Draw the gripper on the bottom right corner
    protected override void OnPaint(PaintEventArgs e)
    {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
            SizeGripStyle = SizeGripStyle.Hide;
    }
    // Override WndProc to add resize ability -> Cursor
    protected override void WndProc(ref Message m)
    {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
    }
