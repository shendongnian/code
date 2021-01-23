            int numStatuses = Enumerable.Range(0, statuses.GetLength(0)).Count(i => statuses[i, 0] != null); //counts not null rows in array
			int numColumns = 9;
			int remainder = numStatuses % numColumns;
			int floorRows = Convert.ToInt32(Math.Floor(Convert.ToDecimal(numStatuses) / Convert.ToDecimal(numColumns)));
			int ceilingRows = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(numStatuses) / Convert.ToDecimal(numColumns)));
			int numRows = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(numStatuses) / Convert.ToDouble(numColumns)));
			int colCount = 0;
			int index = 0;
			double colWidth = Math.Round((100.00 / numColumns), 2);
			String statusHTML = null;
                statusHTML = "<table width=\"100%\">\n<tr>\n<td width=\"" + colWidth + "%\">";
				for (int i = 0; i < numColumns; i++) // runs for the total number of columns
				{
					if (index < numStatuses) // doesn't print blank array values
					{
						if (colCount < remainder) // columns that go down all the way
						{
							for (int j = 0; j < ceilingRows; j++)
							{
								statusHTML += "<div class=\"" + statuses[index, 1] + "\">" + statuses[index, 0] + "</div>";
								index++;
							}
						}
						else // columns that don't go down all the way
						{
							for (int j = 0; j < floorRows; j++)
							{
								statusHTML += "<div class=\"" + statuses[index, 1] + "\">" + statuses[index, 0] + "</div>";
								index++;
							}
						}
						colCount++;
						if (colCount < numColumns && colCount < numStatuses) // checks if done with column
						{
							statusHTML += "</td><td width=\"" + colWidth + "%\">";
						}
						else if (colCount == numColumns)
						{
							colCount = 0;
						}
					}
				}
				if (numStatuses < numColumns) // if it's only one row
				{
					for (int j = 0; j < numColumns - numStatuses; j++)
					{
						statusHTML += "</td>\n<td width=\"" + colWidth + "%\">";
					}
				}
				statusHTML += "</td>\n</tr>\n</table>";
			}
