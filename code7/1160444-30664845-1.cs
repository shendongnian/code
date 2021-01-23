    Series S = chart1.Series[0];
    ChartArea CA = chart1.ChartAreas[0];
    Axis AY = CA.AxisY;
    S.Points.AddXY(1, 10);      S.Points.AddXY(2, 40);
    S.Points.AddXY(3, 50);      S.Points.AddXY(4, 100);
    S.Points.AddXY(5, 111);  
    S.IsValueShownAsLabel = true;
    S.Label = "#PERCENT{P0}";
    S.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
    double max = S.Points.Max(x => x.YValues[0]);
    for (int i = 0; i < S.Points.Count; i++)
    {
        DataPoint dp =  S.Points[i];
        double y0 = S.Points[i].YValues[0];
        AY.CustomLabels.Add(y0, y0 + 1, (y0 / max * 100f).ToString("0.0") + "%");
    }
