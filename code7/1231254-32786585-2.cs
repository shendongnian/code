    protected void FILL_DATA (object sender, EventArgs e)
	{
		DataTable IACS = new DataTable ();
		IACS = GenerateTransposedTableinCsharp (generateIacs ());
		for (int i = 6; i <= 8; i++) {
				
			string rowText = "A0" + i; // this gets updated for each outer iteration
				
			for (int j = 1; j <= 14; j++) {
				string text = rowText + j; // text is now in the form A0XJ
				// convert string to object id
			}
		}
	}
