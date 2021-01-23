    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var colors = new[] {"Red", "Green", "Blue", "Brown", "Cyan", "Magenta"};
            this.DataContext =
                Enumerable.Range(0, 5)
                    .Select(x => new DataItem
                    {
                        Text = "Test" + x.ToString(),
                        Color = colors[x],
                        IsChecked = x%2 == 0
                    });
        }
    }
