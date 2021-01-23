    private void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        foreach (DataPoint dp in s_.Points)
            if (((RectangleF)dp.Tag).Contains(e.Location))
            {
                dp.Color = Color.Orange;
                dp_ = dp;
                break;
            }
    }
