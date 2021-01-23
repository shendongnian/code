	public class LayoutAdapter
	{
		public Layout ComputeBestGridLayout(int elementsCount, double elementRatio, double panelRatio)
		{
			IEnumerable<Layout> possibleLayouts = GetPossibleLayouts(elementsCount);
			return FindBestLayouts(possibleLayouts, elementRatio, panelRatio);
		}
		private IEnumerable<Layout> GetPossibleLayouts(int elementCounts)
		{
			//TODO Increment "elementsCounts", because maybe with some hole we will have a better match for the ratio
			List<Layout> acceptedResults =new List<Layout>();
			for (int i1 = 0; i1 <= elementCounts; i1++)
			{
				double rest2 = elementCounts%((double) i1);
				if (rest2 == 0)
				{
					int i2 = elementCounts/i1;
					acceptedResults.Add(new Layout(i1,i2));
				}
			}
			return acceptedResults;
		}
		private Layout FindBestLayouts(IEnumerable<Layout> possibleLayouts, double elementRatio, double panelRatio)
		{
			Layout closestLayout = null;
			double minDiff=Double.MaxValue;
			
			foreach (Layout possibleLayout in possibleLayouts)
			{
				double currentDiff = Math.Abs((panelRatio/ elementRatio) - possibleLayout.Ratio);
				if (currentDiff < minDiff)
				{
					minDiff = currentDiff;
					closestLayout = possibleLayout;
				}
			}
			return closestLayout;
		}
	}
