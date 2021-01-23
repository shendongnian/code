    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public int BoxA { get; set; }
        public int BoxB { get; set; }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Added value= " + Manipulate.Add(this.BoxA, this.BoxB));
        }
    }
    public static class Manipulate
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
