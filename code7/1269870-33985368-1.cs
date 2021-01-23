    void timer_Tick(object sender, EventArgs e)
    {
          
            pnlBox.Location = new Point(
            pnlBox.Location.X - 2, pnlBox.Location.Y);
            string BoxLocationString = pnlBox.Location.ToString();
            lblXY.Text = BoxLocationString;
    }
