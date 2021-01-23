    using System.Collections.ObjectModel;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            public ObservableCollection<ItemViewModel> Items { get; } =
                new ObservableCollection<ItemViewModel>
                {
                    new ItemViewModel { Name = "Item1", IsChecked = null },
                    new ItemViewModel { Name = "Item2", IsChecked = true },
                    new ItemViewModel { Name = "Item3", IsChecked = false }
                };
        }
        public class ItemViewModel
        {
            public string Name { get; set; }
            public bool? IsChecked { get; set; }
        }
    }
