    public class MatrixTable
    {
        public static string[] columnNames;
        public static bool initialised = false;
        public string EmployeeName { get; set; }
        public string ColumnName { get; set; }
        public DateTime Date { get; set; }
        public DataTable ProcessRow(DataTable table)
        {
            bool found = false;
            foreach(DataRow row in table.Rows)
            {
                if (row["Employeename"] == EmployeeName)
                {
                    found = true;
                    row[ColumnName] = Date;
                    break;
                }
            }
            if(!found)
            {
                DataRow row = table.NewRow();
                row["Employeename"] = EmployeeName;
                row[ColumnName] = Date;
                table.Rows.Add(row);
            }
            return table;
        }
    }
