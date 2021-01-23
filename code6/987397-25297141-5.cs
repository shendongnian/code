    using System.Collections.ObjectModel;
    using System.ComponentModel;
    namespace WpfApplication1.ViewModels
    {
        public class ComboBoxResetViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private ObservableCollection<ItemViewModel> _items;
            public ObservableCollection<ItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }
            private ItemViewModel _selectedItem;
            public ItemViewModel SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged("SelectedItem"); } }
            private bool _isNullValueSelected;
            public bool IsNullValueSelected { get { return _isNullValueSelected; } set { _isNullValueSelected = value; OnPropertyChanged("IsNullValueSelected"); } }
            public ComboBoxResetViewModel()
            {
                this.Items = new ObservableCollection<ItemViewModel>()
                    {
                        new ItemViewModel() { Name = "Item 1" },
                        new ItemViewModel() { Name = "Item 2" },
                        new ItemViewModel() { Name = "Item 3" },
                        new ItemViewModel() { Name = "Item 4" },
                        new ItemViewModel() { Name = "Item 5" }
                    };
            }
        }
        public class ItemViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private string _name;
            public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        }
    }
