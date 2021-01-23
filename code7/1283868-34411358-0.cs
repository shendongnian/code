            Series Series1 = new Series();
            Series Series2 = new Series();
		    Series Series3 = new Series(); 
            Series1.ChartType = SeriesChartType.Column;
            Series2.ChartType = SeriesChartType.StackedColumn;
		    Series3.ChartType = SeriesChartType.StackedColumn;
            
		    int series1Data=30;
		    int series2Data=40;
			int series3Data=series2Data-series1Data;
		    series2Data=series1Data;
		
            Series1.Points.Add(series1Data);
            Series2.Points.Add(series2Data);
		    Series2.Points.Add(series3Data);
            Chart1.Series.Add(Series1);
            Chart1.Series.Add(Series2);
		    Chart1.Series.Add(Series3);
