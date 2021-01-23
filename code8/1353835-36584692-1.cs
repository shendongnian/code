    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private readonly ObservableCollection<ToggleButton> _collection;
    
            public MainWindow()
            {
                InitializeComponent();
    
                _collection = new ObservableCollection<ToggleButton>();
    
                DataContext = _collection;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var toggleButton = new ToggleButton
                {
                    Content = "Toggle" + _collection.Count
                };
                _collection.Add(toggleButton);
            }
        }
    }
