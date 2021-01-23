    public void UpdateEndValues(List<TypeLogSettingsCellItem> list)
	 {
		int highestEndValue = list.Max (x => x.End);
		int highestStartValue = list.Max (x => x.Start);
		for(int i = 0; i < list.Count -1; i++)
		{
			list[i].End = list[i+1].Start;
		}
		if (highestEndValue >= highestStartValue) {
			list [list.Count - 1].End = highestEndValue;
		}
		else if (highestEndValue < highestStartValue) {
			list [list.Count - 1].End = highestStartValue;
		}
	}
