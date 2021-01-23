    public class Test
    {
        public string T { get; set; }
    }
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new List<Test>()
        {
            new Test(){T = "1"}
        };
    }
    <ComboBox  ItemsSource="{Binding T}"/>
