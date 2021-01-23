    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        Point mp = e.Location;
        Legend L = chart1.Legends[0];
        RectangleF LCR = LegendClientRectangle(chart1, L);
        if ( LCR.Contains(mp) )
        {
            int yh = (int) (LCR.Height / chart1.Series.Count);
            int myRel = (int)(mp.Y - LCR.Y);
            int ser = myRel / yh;             // <--- this is the series index
            Series S = chart1.Series[ser];    // add check here!
            // decide which you have set and want to use..:
            string text = S.LegendText != "" ?  S.LegendText : S.Name;
            Console.WriteLine("Series # " + ser + " ->  " + text);
        }
    }
