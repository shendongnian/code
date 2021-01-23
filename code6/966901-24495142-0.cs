    public MainWindow(){
        InitializeComponent();
        this.MyGrid.SelectionChanged += MyGrid_SelectionChanged;
    }
    void MyGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        Messenger.Default.Send<IList>(this.MyGrid.SelectedItems);
    }
