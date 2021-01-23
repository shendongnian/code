		private void build()
		{
			for (int i = 0; i < boundData.Count; i++)
			{
				var chart = new Chart();
				var ser = new Series();
				chart.ChartAreas.Add(new ChartArea("Area1"));
				ser.ChartArea = "Area1";
				ser.Name = "Series1";
				ser.ChartType = SeriesChartType.Bar;
				ser.Color = System.Drawing.Color.Blue; ;
				chart.Series.Add(ser);
				charts.Add(chart);
				for (int j = 0; j < boundData[i].Count; j++)
				{
					charts[i].Series["Series1"].Points.AddXY(j, boundData[i][j]);
				}
			}
			//Just for tesing Purposes
			charts[1].Invalidate();
			charts[1].SaveImage("met.png", ChartImageFormat.Png);
		}
