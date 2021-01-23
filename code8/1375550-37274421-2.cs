    ca.AxisX.IsLogarithmic = true;
    ca.AxisX.LogarithmBase = 10;
    // with 10 as the base it will go to 1, 10, 100, 1000..
    ca.AxisX.Interval = 1;
    // this adds 4 tickmarks into each interval:
    ca.AxisX.MajorTickMark.Interval = 0.25;
    // this add 8 gridlines into each interval:
    ca.AxisX.MajorGrid.Interval = 0.125;
    // this sets two i.e. adds one extra label per interval
    ca.AxisX.LabelStyle.Interval = 0.5;
    ca.AxisX.LabelStyle.Format = "#0.0";
