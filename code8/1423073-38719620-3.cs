    private DataTable CreateEmployeesTable()
    {
        var table = new DataTable()
        {
            Columns = { "EmployeeName", "Company" },
            TableName = "Employees"
        };
        table.Rows.Add("John Doe", "Fresno");
        table.Rows.Add("Billy", "Fresno");
        table.Rows.Add("Tom", "Kern");
        table.Rows.Add("King Smith", "Kings");
        return table;
    }
