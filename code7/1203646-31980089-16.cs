    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Loaded += (sender, args) =>
            {
                this.DataContext = Enumerable.Range(0,100)
                                             .Select(x => new Game())
                                             .ToList();
            };
        }
    }
