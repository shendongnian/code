	var isMonth = <true if Month is selected, false if Yaer is selected>;
	var query = int.Parse(searchBox.Text);
	var rowSources = searchInDt.AsEnumerable()
							   .Where(row => isMonth ? row.Field<DateTime>(getSelectedItem).Month == query
													 : row.Field<DateTime>(getSelectedItem).Year == query);
