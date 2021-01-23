     public MainWindow()
            {
                InitializeComponent();
    
                //Initialize DataContext with some Data
                var dataContext = new DataViewCollectionModel
                {
                    DataVMs = new ObservableCollection<DataViewModel>()
    
                };
                dataContext.DataVMs.Add(new DataViewModel { Un = 1, Deux = 2 });
                dataContext.DataVMs.Add(new DataViewModel { Un = 10, Deux = 20 });
                dataContext.DataVMs.Add(new DataViewModel { Un = 100, Deux = 200 });
    
                //Assign
                DataContext = dataContext;
            }
