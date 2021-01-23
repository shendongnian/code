    public MyControl()
    {
       InitializeComponent();
       Loaded += MyControl_Loaded;
    }
    private void MyControl_Loaded(object sender, RoutedEventArgs e)
    {   
      (DataContext.GetType().GetProperty("LoadedCommand")?.
        GetValue(DataContext) as ICommand)?.
        Execute(null);
    }
