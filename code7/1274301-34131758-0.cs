	var dt = new DataTable();
	dt.Columns.Add("Salary", typeof(string));
	
    // test values
	dt.Rows.Add("0.10000");
	dt.Rows.Add(".1");
	dt.Rows.Add("-.1");
	dt.Rows.Add("1.1");
	
	decimal salary;
	string userInput = "0.10";
	if (decimal.TryParse(userInput, out salary))
	{			
		DataRow[] matchedRows = dt.Select("Convert(Salary, 'System.Decimal') = " + salary.ToString());
		foreach(var r in matchedRows)
			Console.WriteLine(r["Salary"]);
	}
