    public class YourViewModel : ViewModelBase
    {
        public YourViewModel()
        {
            PopulateDataTable();
        }
        private void PopulateDataTable()
        {
            var _ds = new DataSet("Test");
            employeeDataTable = new DataTable();
            employeeDataTable = _ds.Tables.Add("DT");
            for (int i = 0; i < 20; i++)
            {                
                //you can set any Header in the following line
                employeeDataTable.Columns.Add(i.ToString());
            }
            for (int i = 0; i < 10; i++)
            {
                var theRow = employeeDataTable.NewRow();
                for (int j = 0; j < 20; j++)
                {
                    theRow[j] = "a";                    
                }
                employeeDataTable.Rows.Add(theRow);
            }
        }
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
    }
