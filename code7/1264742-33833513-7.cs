    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestDB())
            {
                //Initialize DataTable
                DataTable table = new DataTable();
                var columnNames = db.Templates.Select(t => t.TemplateName).ToArray();
                table.Columns.Add("Employeename", typeof(string));
                foreach (var name in columnNames)
                {
                    DataColumn column = new DataColumn(name, typeof(DateTime));
                    column.AllowDBNull = true;
                    table.Columns.Add(column);
                }
                //Get Matrix objects
                var result = db.Matrices.Select(m => new MatrixCell
                {
                    ColumnName = m.Template.TemplateName,
                    Date = (DateTime)m.Date,
                    EmployeeName = m.Employee.EmployeeName
                }).ToArray();
                //Populate datatable
                foreach (var matrix in result)
                    table = matrix.ProcessRow(table);
                Console.Read();
            }
        }
    }
