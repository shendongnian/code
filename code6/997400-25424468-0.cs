    StripLine sline = new StripLine();
    sline.IntervalOffset = <the start point>;
    sline.StripWidth = <the duration>;
    //sline.Text = "You can set a label";
    sline.Interval = 0.0D; // IMPORTANT: prevent repeating striplines
    sline.BackColor = Color.AliceBlue;
    sline.BorderColor = Color.LightSteelBlue;
    Chart.AxisX.StripLines.Add(sline);
