    using System.Windows.Forms.DataVisualization.Charting;
    
    private List<Chart> MakeCharts(string[] YourArray)
    {
        var myChart = new List<Chart>();
        Foreach(string chName in YourArray)
        {
            ChartArea area = new ChartArea();
            area.Name = chName;
            Chart chart = new Chart();
            chart.Name = chName;
            Series series1 = new Series();
            Series series2 = new Series();
            
            area.Position.Auto = false;
            chart.ChartAreas.Add(area);
            chart.Location = new System.Drawing.Point(216, 43);
            series1.ChartType = SeriesChartType.StackedBar100;
            series1.Name = "Series1";
            series2.ChartType = SeriesChartType.StackedBar100;
            series2.Name = "Series2";
            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Size = new System.Drawing.Size(100, 34);
            chart.TabStop = false;
            //Here is the tricky part.  See explanation after code.
            chart.Click += new System.EventHandler(charts_Click);
            myChart.Add(chart);
        }
        return myChart;
    }
