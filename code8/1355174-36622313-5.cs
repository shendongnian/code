    // show the year in the legend:
    S1.LegendText = "Year " + dt.Year;
    // move to the bottom center:
    chart1.Legends[0].Docking = Docking.Bottom;
    chart1.Legends[0].Alignment = StringAlignment.Center;
    S1.XValueType = ChartValueType.Date;  // set the type
    XA.MajorGrid.Enabled = false;         // no gridlines
    XA.LabelStyle.Forma t = "MMM";         // show months as names
    XA.IntervalType = DateTimeIntervalType.Months;  // show axis labels.. 
    XA.Interval = 1;                                // ..every 1 months
    YA.LabelStyle.Format = "##0$";  // for kilos etc you need to scale the y-values!
