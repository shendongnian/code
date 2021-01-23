    var objects = mySQLiteConnection.RunSql("SELECT * FROM Persons", true);
	// ColumnNames
    List<string> ColumnNames = new List<string>();
	for (int column = 0; column < objects[0].Length; column++)
	{
		if (objects[0][column] != null) spaltennamen.Add((string)objects[0][column]);
	}
    // RowValues
	for (int row = 1; row < objects.Count; row++)
	{
		for (int column = 0; column < objects[row].Length; column++)
		{
			if (objects[row][column] != null) System.Diagnostics.Debug.WriteLine(spaltennamen[column] + " : " + objects[row][column]);
		}
	}
