			// Read data from files
			List<string> inputFileNames = new List<string> {"File1.txt", "File2.txt", "File3.txt"};
			decimal[][] fieldValues = new decimal[inputFileNames.Count][];
			for (int i = 0; i < inputFileNames.Count; i++)
			{
				string currentInputfileName = inputFileNames[i];
				string[] currentInputFileLines = File.ReadAllLines(currentInputfileName);
				fieldValues[i] = new decimal[currentInputFileLines.Length];
				for (int j = 0; j < currentInputFileLines.Length; j++)
				{
					fieldValues[i][j] = decimal.Parse(currentInputFileLines[j]);
				}
			}
			// Create table
			DataTable table = new DataTable();
			DataColumn field1Column = table.Columns.Add("field1", typeof (decimal));
			DataColumn field2Column = table.Columns.Add("field2", typeof (decimal));
			DataColumn field3Column = table.Columns.Add("field3", typeof (decimal));
			for (int i = 0; i < fieldValues[0].Length; i++)
			{
				var newTableRow = table.NewRow();
				newTableRow[field1Column.ColumnName] = fieldValues[0][i];
				newTableRow[field2Column.ColumnName] = fieldValues[1][i];
				newTableRow[field3Column.ColumnName] = fieldValues[2][i];
				table.Rows.Add(newTableRow);
			}
			// Sorting 
			table.DefaultView.Sort = field1Column.ColumnName;
			
			// Output 
			foreach (DataRow row in table.DefaultView.ToTable().Rows)
			{
				foreach (var item in row.ItemArray)
				{
					Console.Write(item + " ");
				}
				Console.WriteLine();
			}
