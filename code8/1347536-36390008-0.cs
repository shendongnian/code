    public Window()
            {
                InitializeComponent();
    
                var Grid = new DataGrid();
    
                //Start Test list creation with three items
                var TestList = new List<Receipt>();
    
                //Set binding
                Grid.ItemsSource = TestList;
                
                var Rec = new Receipt();
                Rec.Creator = "DaJohn1";
                Rec.ID = 1;
                Rec.Title = "TestReceipt1";
    
                var Rec2 = new Receipt();
                Rec2.Creator = "DaJohn2";
                Rec2.ID = 2;
                Rec2.Title = "TestReceipt2";
    
                var Rec3 = new Receipt();
                Rec3.Creator = "DaJohn3";
                Rec3.ID = 3;
                Rec3.Title = "TestReceipt3";
    
                TestList.Add(Rec);
                TestList.Add(Rec2);
                TestList.Add(Rec3);
                //End Test list creation
    
                //Add Column
                var SingleColumn = new DataGridTextColumn();
                Grid.Columns.Add(SingleColumn);
                SingleColumn.Binding = new Binding("Creator");
                SingleColumn.Header = "Creator";
    
                //Add Column
                var SingleColumn2 = new DataGridTextColumn();
                Grid.Columns.Add(SingleColumn2);
                SingleColumn2.Binding = new Binding("Title");
                SingleColumn2.Header = "Title";
    
                //Set tabitem content to datagrid
    
                Grid.AutoGenerateColumns = false;
                firstdish.Content = Grid;
            }
