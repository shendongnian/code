    public partial class MainWindow : Window, IManipulate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_Add(object sender, RoutedEventArgs e)
        {
            Manipulate.Add(this);
        }
    }
    public static class Manipulate
    {
        public static void Add(IManipulate e)
        {
           MessageBox.Show("Added value= " + (e.X + e.Y).toString());
        }
    }
