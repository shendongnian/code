    //Just pass your list of dates to this function
    private void DrawTimeline(List<DateTime> dates)
    {
        
        //chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
        //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
        //chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
        
        //initialize a legend with some settings
        chart1.Legends.Clear();
        chart1.Legends.Add("Timespans");
        chart1.Legends[0].LegendStyle = LegendStyle.Table;
        chart1.Legends[0].Docking = Docking.Bottom;
        chart1.Legends[0].Alignment = StringAlignment.Center;
        chart1.Legends[0].Title = "Timespans";
        chart1.Legends[0].BorderColor = Color.Black;
        chart1.Series.Clear();
        string seriesname;
        //adding the bars with some settings
        for (int i = 0; i < dates.Count-1; i++)
        {
            seriesname = Convert.ToString(dates[i].Date + " - " + dates[i + 1].Date);
            chart1.Series.Add(seriesname);
            chart1.Series[seriesname].ChartType = SeriesChartType.RangeBar;
            chart1.Series[seriesname].YValuesPerPoint = 2;
            chart1.Series[seriesname].Points.AddXY("Timeline", dates[i].Date, dates[i + 1].Date);
            chart1.Series[seriesname]["DrawSideBySide"] = "false";
            chart1.Series[seriesname].BorderColor = Color.Black;
            chart1.Series[seriesname].ToolTip = seriesname;
        }
    }
