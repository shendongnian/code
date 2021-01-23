		int[] i = { 1, 2, 3, 4, 5 };
		int iSum = 0;
		float flAvg = 0.0f;
		int iMax = 0;
		int iMin = Int32.MaxValue;
		foreach (int iElement in i)
		{
			iSum = iSum + iElement;
			flAvg = flAvg + iElement;
			if (iElement > iMax)
			{
				iMax = iElement;
			}
			if (iElement < iMin)
			{
				iMin = iElement;
			}
		}
			flAvg = flAvg / i.Length;
    //carry on to do stuff with the data down here.
