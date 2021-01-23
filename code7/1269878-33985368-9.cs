    void timer_Tick(object sender, EventArgs e)
    {
            if (pnlBox.Location.X >= 316)
            {
                Step = -2;
            }
            if (pnlBox.Location.X <= 0) 
            {
                Step = 2;
            }
    
            pnlBox.Location = new Point(
            pnlBox.Location.X + Step , pnlBox.Location.Y);
            string BoxLocationString = pnlBox.Location.ToString();
            lblXY.Text = BoxLocationString;
    }
