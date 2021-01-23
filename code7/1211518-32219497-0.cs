		// Initial table set up and population
		DataTable originalTable = new DataTable("originaltable");
		originalTable.Columns.Add("CurveNumber", (123).GetType());
		originalTable.Columns.Add("ObjectID", ("String").GetType());
		originalTable.Columns.Add("Length", (123).GetType());
		originalTable.Columns.Add("Radius", (123).GetType());
		originalTable.Columns.Add("Delta", (123).GetType());
		originalTable.Columns.Add("Tangent", (123).GetType());
		
		originalTable.Rows.Add(new object[] { 1, "0851ax", 20, 20, 20, 20} );
		originalTable.Rows.Add(new object[] { 2, "0852ab", 20, 20, 20, 20} );
		originalTable.Rows.Add(new object[] { 3, "0853ac", 25, 32, 12, 10} );
		originalTable.Rows.Add(new object[] { 4, "0854ad", 12, 31, 15, 20} );
		originalTable.Rows.Add(new object[] { 5, "0855ca", 20, 20, 20, 20} );
		originalTable.Rows.Add(new object[] { 6, "0856ad", 25, 32, 12, 10} );
		
		// Create a new datatable containing the unique values
		// for the four columns in question
		DataTable uniqueValues = (new DataView(originalTable))
									.ToTable(true, new string[] {"Length", 
																 "Radius", 
																 "Delta", 
																 "Tangent"});
		// Create a DataSet of DataTables each one containing the grouped
		// rows based on matches on the four columns in question.
		DataSet groupedRows = new DataSet("groupedRows");
		foreach (DataRow uniqueValue in uniqueValues.Rows) {
			
			// Create the individual table of grouped rows based on the
			// structure of the original table
			DataTable groupTable = originalTable.Clone();
			groupTable.TableName = String.Format("{0}-{1}-{2}-{3}", 
												 uniqueValue["Length"], 
												 uniqueValue["Radius"], 
												 uniqueValue["Delta"], 
												 uniqueValue["Tangent"]);
			
			// Fetch the rows from the original table based on matching to the
			// unique combination of four columns
			DataRow[] groupRows = originalTable.Select(String.Format(" Length = {0} AND Radius = {1} AND Delta = {2} AND Tangent = {3} ", 
																	 uniqueValue["Length"], 
																	 uniqueValue["Radius"], 
																	 uniqueValue["Delta"], 
																	 uniqueValue["Tangent"]));
			
			// Add each matched row into the individual grouped DataTable
			foreach (DataRow groupRow in groupRows) {
				groupTable.Rows.Add(groupRow.ItemArray);
			}
			
			// Finally, add the DataTable to the DataSet
			groupedRows.Tables.Add(groupTable);
		}
		
