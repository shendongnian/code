        using System.Windows.Forms.DataVisualization.Charting;
        //..
        chart1.Series.Clear();
        Series S1 = chart1.Series.Add("Pie1");
        Series S2 = chart1.Series.Add("Pie2");
        chart1.ChartAreas.Clear();
        ChartArea CA1 = chart1.ChartAreas.Add("Outer");
        ChartArea CA2 = chart1.ChartAreas.Add("Inner");
        CA1.Position = new ElementPosition(0, 0, 100, 100);
        CA2.Position = new ElementPosition(0, 0, 100, 100);
        float innerSize = 60;
        float outerSize = 100;
        float baseDoughnutWidth = 25;
        CA1.InnerPlotPosition = new ElementPosition((100 - outerSize) / 2,
                (100 - outerSize) / 2 + 10, outerSize, outerSize - 10);
        CA2.InnerPlotPosition = new ElementPosition((100 - innerSize) / 2,
                (100 - innerSize) / 2 + 10, innerSize, innerSize - 10);
        S1["DoughnutRadius"] = 
         Math.Min(baseDoughnutWidth * (100 / outerSize), 99).ToString().Replace(",", ".");
        S2["DoughnutRadius"] = 
         Math.Min(baseDoughnutWidth * (100 / innerSize), 99).ToString().Replace(",", ".");
        
        S1.ChartArea = CA1.Name;
        S2.ChartArea = CA2.Name;
        S1.ChartType = SeriesChartType.Doughnut;
        S2.ChartType = SeriesChartType.Doughnut;
        CA2.BackColor = Color.Transparent;
        S1["DoughnutRadius"] = "41"; // leave just a little space!
        S2["DoughnutRadius"] = "99"; // 99 is the limit. a tiny spot remains open
        // test data, optional, R is a Random instance
        for (int i = 0; i < 7; i++)
        {
            S1.Points.AddXY(i, 42 - R.Next(44));
            S2.Points.AddXY(i, 77 - R.Next(88));
        }
    }
