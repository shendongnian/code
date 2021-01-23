    private void AssertColumnIsOrderedByDateDescending(int columnIndex)
		{
			Dictionary<int, ReadOnlyCollection<IWebElement>> tableData = Driver.GetTableData(IssuesTableBodySelector);
			DateTime previousDate = DateTime.Now.AddDays(1);
			foreach (ReadOnlyCollection<IWebElement> webElements in tableData.Values)
			{
				string dateTimeString = webElements.ElementAt(columnIndex).Text;
				if (string.IsNullOrWhiteSpace(dateTimeString))
					continue;
				DateTime currentDate = DateTime.Parse(dateTimeString);
				Assert.LessOrEqual(currentDate, previousDate);
				previousDate = currentDate;
			}
		}
