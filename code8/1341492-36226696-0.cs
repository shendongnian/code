    public class MainWindowViewModel:ViewModelBase
    {
        public MainWindowViewModel()
        {
            PopulateDataTable();
            RepopulateCommand = new RelayCommand(RepopulateDataTable);
        }
        private DataTable employeeDataTable;
        public DataView EmployeeDataView
        {
            get { return employeeDataTable.DefaultView; }
        }       
        public RelayCommand RepopulateCommand { get; set; }
       
        private void PopulateDataTable()
        {
            employeeDataTable = new DataTable();
            for (int i = 0; i < 10; i++)
            {
                employeeDataTable.Columns.Add("Column " + i.ToString());
            }
            for (int i = 0; i < 15; i++)
            {
                var theRow = employeeDataTable.NewRow();
                for (int j = 0; j < 10; j++)
                {
                    theRow[j] = "a";
                }
                employeeDataTable.Rows.Add(theRow);
            }
            OnPropertyChanged("EmployeeDataView");
        }
        private void RepopulateDataTable(object obj)
        {
            employeeDataTable.Clear();
            for (int i = 0; i < 10; i++)
            {
                var theRow = employeeDataTable.NewRow();
                for (int j = 0; j < 10; j++)
                {
                    theRow[j] = j + DateTime.Now.ToString();
                }
                employeeDataTable.Rows.Add(theRow);
            }
            OnPropertyChanged("EmployeeDataView");
        }
