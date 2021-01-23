    public MainWindow()
    {
        InitializeComponent();
        FillDataGrid();
    }
    private void FillDataGrid()
    {
       ObservableCollection<MChiStructure> coll = new ObservableCollection<MChiStructure>();
       for (int start = 0; start < 10; start++)
       {
          coll.Add(new MChiStructure(){TitleField="Title " + start.ToString(), 
          chiV1Minus=start-1, chiV1Plus=start+1, mV1Plus=start-1});                                
       }
       dataGrid.ItemsSource = coll;       
    }
