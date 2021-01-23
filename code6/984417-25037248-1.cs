    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
               myTextBox.SetValue(Canvas.LeftProperty,(double)myTextBox.GetValue(Canvas.LeftProperty)+50.0);
            }
        }
    }
