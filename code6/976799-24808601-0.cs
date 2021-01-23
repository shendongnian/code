     [STAThread]
     public MainWindow()
        {
            InitializeComponent();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();           
            InitializeBackgroundWorker();
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            tabItemList.CollectionChanged += this.TabCollectionChanged;
        }
