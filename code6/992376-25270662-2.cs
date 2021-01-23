    using System.Windows;
    namespace WpfMagic
    {
        public partial class MainWindow : Window
        {
            public MyViewModel Model { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                Model = new MyViewModel();
                this.DataContext = this;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                new AnotherWindow(Model).Show();
            }
        }
    }
