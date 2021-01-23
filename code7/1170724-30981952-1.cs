    public MainWindow()
            {
                InitializeComponent();
                
                //Initialize your data here
                GroupedMedia gm = new GroupedMedia();
                //Initialize your data here
    
                this.dgTest.ItemsSource = gm.MediaList;
            }
