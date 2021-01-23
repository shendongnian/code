    private void RepopulateDataTable(object obj)
    {
        EmployeeDataTable.Clear();
        for (int i = 0; i < 10; i++)
        {
            var theRow = employeeDataTable.NewRow();
            for (int j = 0; j < 10; j++)
            {
                theRow[j] = j + DateTime.Now.ToString();
            }
            employeeDataTable.Rows.Add(theRow);        
        }
        DataTable tempDataTable = EmployeeDataTable;
        EmployeeDataTable = null;
        EmployeeDataTable = tempDataTable;
    }
