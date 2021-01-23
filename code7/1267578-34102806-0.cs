        public MainWindow()
        {
            InitializeComponent();
            PopulateDataGrid();
        }
        DataTable employeeDataTable = new DataTable();
        private void PopulateDataGrid()
        {
            var _ds = new DataSet("Test");
            
            employeeDataTable = _ds.Tables.Add("DT");
            for (int i = 0; i < 10; i++)//create columns
            {   
                if(i==0)
                    employeeDataTable.Columns.Add("Row");                
                employeeDataTable.Columns.Add(i.ToString());
            }
            for (int i = 0; i < 10; i++)//fill data to rows
            {
                var theRow = employeeDataTable.NewRow();
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        theRow[j] = (i + 1);
                        continue;
                    }
                    if (j % 2 == 0)                    
                        theRow[j] = "a";  
                    else                  
                        theRow[j] = "b";
                }
                employeeDataTable.Rows.Add(theRow);
            }
            dataGrid.ItemsSource = employeeDataTable.AsDataView();
        }
