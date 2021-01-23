    Series S1 = chart.Series["Bench-Mark"];
    foreach (var item in listGP)
    {
        DateTime dt = Convert.ToDateTime(item);
        int p = S1.Points.AddXY(dt, listGP[item]);
        string l = dt.ToString("MMM-yyyy");
        S1.Points[p].AxisLabel = l;
    }
