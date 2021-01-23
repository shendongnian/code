    for(int i=0;i<24;i++)
    {
        var stripLine = new StripLine();
        stripLine.BackColor = Color.White;
        stripLine.BackGradientStyle = GradientStyle.TopBottom;
        stripLine.BackImageTransparentColor = Color.White;
        stripLine.BackSecondaryColor = Color.Transparent;
        stripLine.Interval = (double)i;
        stripLine.IntervalType = DateTimeIntervalType.Hours;
        stripLine.IntervalOffset = 50;
        stripLine.IntervalOffsetType = DateTimeIntervalType.Minutes;
        stripLine.StripWidth = 20;
        stripLine.StripWidthType = DateTimeIntervalType.Minutes;
        Chart1.ChartAreas[0].AxisX.StripLines.Add(stripLine);
    }
