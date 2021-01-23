    using System.Collections.ObjectModel;
    using System.ComponentModel;
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
        public class ItemViewModel : INotifyPropertyChanged
        {
            public string Name { get; set; }
            private bool? _isChecked;
            public bool? IsChecked
            {
                get { return _isChecked; }
                set
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
