    GraphicsPath GP = new GraphicsPath();
    Rectangle fillGap(Rectangle R1, Rectangle R2, bool isTop, bool isLeft )
    { 
        int LeftMin    = Math.Min(R1.Left, R2.Left);
        int RightMax   = Math.Max(R1.Right, R2.Right);
        int TopMin     = Math.Min(R1.Top, R2.Top);
        int BotMax     = Math.Max(R1.Bottom, R2.Bottom);
        int RightGap   = 2 * Math.Abs(R1.Right - R2.Right);
        int LeftGap    = 2 * Math.Abs(R1.Left - R2.Left);
        int TopGap     = 2 * Math.Abs(R1.Top - R2.Top);
        int BotGap     = 2 * Math.Abs(R1.Bottom - R2.Bottom);
        Rectangle R = Rectangle.Empty; 
        if (isTop && isLeft) R = new Rectangle(LeftMin, TopMin, LeftGap, TopGap);
        if (isTop && !isLeft) 
            R = new Rectangle(RightMax - RightGap, TopMin, RightGap, TopGap);
        if (!isTop && !isLeft) 
            R = new Rectangle(RightMax - RightGap, BotMax  - BotGap , RightGap, BotGap );
        if (!isTop && isLeft) 
            R = new Rectangle(LeftMin, BotMax  - BotGap , LeftGap, BotGap );
         return R;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        findBorderRect(curMouseRect);
        Rectangle Rtop = new Rectangle(20, 10, 200, 40);
        Rectangle Rbottom = new Rectangle(20, 200, 200, 40);
        Rectangle Rleft = new Rectangle(10, 20, 40, 200);
        Rectangle Rright = new Rectangle(210, 20, 40, 200);
        GP = new GraphicsPath(); 
        GP.FillMode = FillMode.Winding;
        GP.AddRectangle(Rtop);
        GP.AddRectangle(Rleft);
        GP.AddRectangle(Rbottom);
        GP.AddRectangle(Rright);
        GP.AddArc(fillGap(Rtop, Rleft, true, true), 0, 360);
        GP.AddArc(fillGap(Rtop, Rright, true, false), 0, 360);
        GP.AddArc(fillGap(Rbottom, Rleft, false, true), 0, 360);
        GP.AddArc(fillGap(Rbottom, Rright, false, false), 0, 360);
        
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Black, 1.5f))
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawPath(pen, GP);
            if(checkBox1.Checked) e.Graphics.FillPath(Brushes.Red, GP);
        }
    }
