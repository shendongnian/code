    public partial class Window1 : Window
    {
        public ObservableCollection<MyData> _data = new ObservableCollection<MyData>();
    
        private const int NumRepeats = 2;
        private const int EnumerationIncrement = 3;
    
        private int _enumerationCount = 3;
    
        public Window1()
        {
            InitializeComponent();
        }
    
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= NumRepeats; i++)
            {
                string data = String.Join(", ", Enumerable.Repeat("Test Data", _enumerationCount));
                _data.Add(new MyData { Col1 = "Test", Col2 = data });
                _enumerationCount += EnumerationIncrement;
            }
        }
    }
