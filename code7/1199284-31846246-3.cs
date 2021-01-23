    public partial class MainWindow : Window
    {
        PieCollection pieCollection1;
        public MainWindow()
        {
            InitializeComponent();
            pieCollection1 = new PieCollection();
            pieCollection1.Add(new PiePoint { Name = "Mango", Share = 10 });
            pieCollection1.Add(new PiePoint { Name = "Banana", Share = 36 });
            pieCollection1.Add(new PiePoint { Name = "Grapes", Share = 15 });
            pieCollection1.Add(new PiePoint { Name = "Apple", Share = 20 });
            Chart1.DataContext = pieCollection1;
        }
    }
