    string csvFile = System.IO.Path.Combine(Application.StartupPath, "aCSVfile.csv");
    List<string[]> rows = File.ReadAllLines(csvFile).Select(x => x.Split(',')).ToList();
    DataTable dataTable = new DataTable();
    
    //add cols to datatable:
    dataTable.Columns.Add("col0");
    dataTable.Columns.Add("col1");
    
    rows.ForEach(x => { dataTable.Rows.Add(x); });
    
    dataGridView.DataSource = dataTable;
    
