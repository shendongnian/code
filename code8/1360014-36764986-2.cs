    var chart = new Chart(width: 300, height: 220).AddTitle("Test");
    if (project!= null)
    {
        Series series1 = new Series("Series1");
        series1.ChartType = "Doughnut";
        foreach (var item in project.module)
        {
            series1.Points.Add(new DataPoint
            {
                AxisLabel = item.TXT_Name,
                YValues = new double[] { item.NUM_Hours },
                Color = Color.Green,
            });
        }
        chart.Series.Add(series1);
    }
    return chart.Write("png");
