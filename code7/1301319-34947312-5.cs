    using System;
    using System.Windows;
    
    namespace WpfApplication2
    {
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                fr.Navigate(new Uri("Page1.xaml", UriKind.Relative));
            }
    
            private void textbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
            {
                if (fr != null) fr.Refresh();
            }
        }
    }
