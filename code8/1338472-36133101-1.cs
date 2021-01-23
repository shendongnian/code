    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.List = new List<string> { "Quien", "vie", "ne", "en", "su", "nom", "bre" };
                InitializeComponent();
                this.DataContext = this;
            }
    
            public List<string> List { get; set; }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
    
               
            }
        }
    }
