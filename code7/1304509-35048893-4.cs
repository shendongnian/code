    using System.Windows;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Delete_Click(object sender, RoutedEventArgs e)
            {
                GlobalCommand<object>.GetInstance(null).Execute(null);// I'm not quite happy with this but it works
            }
        }
    }
