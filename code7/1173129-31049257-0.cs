        List<int> stringLength = new List<int> { }; // storing every length
		foreach (string entry in ddlTemplate.Items)
		{
			stringLength.Add(entry.Length); // saving each string-length
		}
		
		int index = stringLength.FindIndex(a => a == stringLength.Min()); // get index of lowst length
		ddlTemplate.SelectedIndex = index; // set selected value to index from above
