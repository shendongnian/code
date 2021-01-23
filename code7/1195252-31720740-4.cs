	GYRStatus? status = null;
	foreach (var pair in fakeStandardsAndSizesFictionary)
	{
	   if (pair.Key.Item1 == factoryCode &&
	   pair.Key.Item2 == technology &&
	   pair.Key.Item3 == transformerType &&
	   pair.Key.Item4 == transformerSize &&
	   pair.Key.Item5 == transformerModel)
	   {
	 	  status = (Enums.GYRStatus)pair.Value;
		  break;
	   }
	}
	return status;
	
