        private DataTable employeeDataTable;
        public DataTable EmployeeDataTable
        {
            get { return employeeDataTable; }
            set
            {
                employeeDataTable = value;
                OnPropertyChanged("EmployeeDataTable");
            }
        }
       var _ds = new DataSet("Test");
                employeeDataTable = new DataTable();
                employeeDataTable = _ds.Tables.Add("DT");
                for (int i = 0; i < 800; i++)
                {
                    //employeeDataTable.Columns.Add(i.ToString() + ".");
                    employeeDataTable.Columns.Add(i.ToString());
                }
                for (int i = 0; i < 2; i++)
                {
                    var theRow = employeeDataTable.NewRow();
                    for (int j = 0; j < 800; j++)
                    {                       
                            theRow[j] = "a";
                        
                    }
                    employeeDataTable.Rows.Add(theRow);
                }
