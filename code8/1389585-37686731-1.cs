    private void HighlightOffenders(IEnumerable<int> listOfIndexes)
		{
			foreach (var index in listOfIndexes.Reverse())
			{
				
				mathEquation.Select(index,1);
				mathEquation.SelectionFont = new Font(mathEquation.Font, FontStyle.Bold);
			}
			
		}
