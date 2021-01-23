    public MainWindow()
    {
        InitializeComponent();
        Letters = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (char)i);
        DataContext = this;
    }
    public IEnumerable<char> Letters { get; set; }
    private void LetterButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        Trace.WriteLine("Clicked " + button.Content);
    }
 
