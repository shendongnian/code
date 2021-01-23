    public MainPage()
    {
        this.InitializeComponent();
        thing.ItemTemplate = (DataTemplate)this.Resources["templateEmployee"];
        thing.Items.Add(new object());
        thing.Items.Add(new object());
    }
