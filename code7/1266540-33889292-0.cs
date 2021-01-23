	private Measure CalculateMeasure(AverageValue av, Dictionary<DateTime, double> average,
									 byte parameter, byte step, DateTime time, string file)
	{
		av.Step = step;
		av.KindOfInfo = parameter;
		average = av.GetInformationForDiagramBetweenTwoTimes(time, file);
		
		var first = average.First();
		
		return new Measure
		{
			Average = first.Value;
			Time = first.Key;
			Parameter = parameter;
		};
	}
	
