    public ColorCheckBox()
    {
        Appearance = System.Windows.Forms.Appearance.Button;
        FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        TextAlign = ContentAlignment.MiddleRight;
        FlatAppearance.BorderSize = 0;
        AutoSize = false;
        Height = 16;
    }
    protected override void OnPaint(PaintEventArgs pevent)
    {
        //base.OnPaint(pevent);
        pevent.Graphics.Clear(BackColor);
        using (SolidBrush brush = new SolidBrush(ForeColor))
            pevent.Graphics.DrawString(Text, Font, brush, 27, 4);
        Point pt = new Point( 4 ,  4);
        Rectangle rect = new Rectangle(pt, new Size(16, 16));
        pevent.Graphics.FillRectangle(Brushes.Beige, rect);
            
        if (Checked)
        {
            using (SolidBrush brush = new SolidBrush(ccol))
            using (Font wing = new Font("Wingdings", 12f))
                pevent.Graphics.DrawString("ü", wing, brush, 1,2);
        }
        pevent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);
        Rectangle fRect = ClientRectangle;
        if (Focused)
        {
            fRect.Inflate(-1, -1);
            using (Pen pen = new Pen(Brushes.Gray) { DashStyle = DashStyle.Dot })
                pevent.Graphics.DrawRectangle(pen, fRect);
        }
    }
