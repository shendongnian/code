	List<Measure> measures = Enumerable.Range(0, 6)
									   .Cast<byte>()
									   .AsParallel()
									   .SelectMany(parameter => 
	{
		var localMeasures = new List<Measure>();
		for (byte step = 0; step < xValues.Count; step++)
		{
			localMeasure.Add(CalculateMeasure(av, average, parameter, step, time, file));
		}
		return localMeasures;
	}).ToList();
	
	this.TimeValueParameter.AddRange(measures);
	
