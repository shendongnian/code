    var pm = new PlotModel();
    pm.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left });
	pm.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, LabelFormatter = labelFormatter });
								
	Random random = new Random(Guid.NewGuid().GetHashCode());
	
	var datapoints = 
		Enumerable.Range(1, 100)
			.Select(milliseconds => new DataPoint(milliseconds, random.Next(0, 10)));
			
	var lineSeries = new OxyPlot.Series.LineSeries();
	lineSeries.Points.AddRange(datapoints);
	pm.Series.Add(lineSeries);
	
	Show(pm);
