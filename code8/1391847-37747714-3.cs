    public partial class MainWindow : Window
    {
        public static TextBox txt1Mirror;
        public static TextBox txt2Mirror;
        public MainWindow()
        {
            InitializeComponent();
            txt1Mirror = txt1;
            txt1Mirror = txt2;
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Manipulate.Add();
        }
    }
    public static class Manipulate
    {
        public static void Add()
        {
           int a = int32.Parse(MainWindow.txt1Mirror.Text);
           int b = int32.Parse(MainWindow.txt2Mirror.Text);
           MessageBox.Show("Added value= " + (a + b));
        }
    }
