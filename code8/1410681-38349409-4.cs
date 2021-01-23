    public MainWindow()
    {
       FillDataGrid();
    }
 
    private DataTable employeeDataTable;
    private void FillDataGrid()
    {
        employeeDataTable = new DataTable();
        employeeDataTable = _ds.Tables.Add("DT");
        for (int i = 0; i < 80; i++)
        {
           employeeDataTable.Columns.Add(i.ToString());
        }
        for (int i = 0; i < 100; i++)
        {
           var theRow = employeeDataTable.NewRow();
           for (int j = 0; j < 80; j++)
           {
              theRow[j] = "a";
           }
           employeeDataTable.Rows.Add(theRow);
        }
        gridEmployees.ItemsSource = employeeDataTable.DefaultView;
    } 
