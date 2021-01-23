     public ICommand MyCommand { get; set; }
        public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                MyCommand = new AwaitableDelegateCommand(refreshGrid);
    
            }
    
         private async Task refreshGrid()
                {
                    await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                      {
                          Thread.Sleep(10000);
                      }));
                }
