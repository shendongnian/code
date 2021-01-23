	int i = 0;
	DataTable dt = new DataTable();
	dt.Columns.Add("My first column Name");
	dt.Columns.Add("My  column Name");
	while (i < pdfFiles.Length)
	{
		var firstPdfFilename = pdfFiles[i].FullName;
		string ama = firstPdfFilename.ToString();
		Excel.Application application = new Excel.Application();
		Excel.Workbook workbookOne;
		workbookOne = application.Workbooks.Open(ama);
		Excel.Worksheet worksheet;
		worksheet = workbookOne.Sheets[1];
		string test = worksheet.Cells[12, 3].Value.ToString();
		workbookOne.Close(true);
		application.Quit();
		DataRow _ravi = dt.NewRow();
		_ravi["My first column Name"] = test;
		_ravi["My  column Name"] = test;
		dt.Rows.Add(_ravi);
		i++;
	}
	dataGridView1.DataSource = dt;
	dataGridView1.AllowUserToAddRows = false;
