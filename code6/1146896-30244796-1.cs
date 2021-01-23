    public MainWindow()
    {
        InitializeComponent();
        var names = Enumerable
            .Range(1, 10)
            .OrderBy(_ => Guid.NewGuid())
            .Select(i =>
                i.ToString());
        foreach (var button in this.CreateNewButtons(names))
        {
            LbFrequentColumnItems.Items.Add(button);                
        }
    }
        
    private IEnumerable<Button> CreateNewButtons(IEnumerable<String> names)
    {
        foreach (var name in names)
        {
            Button b = new Button();
            b.Content = name;
            b.Click += new RoutedEventHandler(OptionalColumnItems_Click);
            yield return b;
        }
    }
    private void OptionalColumnItems_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
