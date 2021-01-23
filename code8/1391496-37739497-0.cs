    public MainWindow() 
    { 
    	InitializeComponent(); 
    	
    	 Loaded += MainWindow_Loaded;
    }
    
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
    	//Timer 	
    	DispatcherTimer timer = new DispatcherTimer(); 
    	timer.Tick += (s, ev) => btnClickMe.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); 
    	timer.Interval = new TimeSpan(0, 5, 0); 
    	timer.Start(); 
    }
