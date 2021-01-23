    var theChart = new Chart();
            //missing part
            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            theChart.ChartAreas.Add(chartArea1);
            var theSeries = new Series("values");
            theSeries.IsVisibleInLegend = false;
            theChart.Series.Add(theSeries);
            theSeries.Points.AddXY(1, 1);
            theSeries.Points.AddXY(2, 2);
            theSeries.Points.AddXY(3, 3);
            theChart.SaveImage(@"D:\Téléchargements\HiddenChart6.png", ChartImageFormat.Png);
