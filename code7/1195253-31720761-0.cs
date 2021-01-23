	public Enums.GYRStatus GetStatusForTransformer(string factoryCode,   Enums.Technology technology, string transformerType, int transformerSize, string transformerModel)
	{
		fakeStandardsAndSizesFictionary = new Dictionary<Tuple<string, Enums.Technology, string, int, string>, int>() 
		{
			{Tuple.Create("SELUD",Technology.CVT,"---",0 ,""),1},
		};
		
		return fakeStandardsAndSizesFictionary
			.Where(pair =>
				pair.Key.Item1 == factoryCode
					&& pair.Key.Item2 == technology
					&& pair.Key.Item3 == transformerType
					&& pair.Key.Item4 == transformerSize
					&& pair.Key.Item5 == transformerModel)
			.Select(pair => (Enums.GYRStatus)pair.Value)
			.First();
	}
