    using System.Windows;
    
    namespace WpfApplication4
    {
        public partial class MainView : Window
        {
            public MainView()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
            }
        }
    }
