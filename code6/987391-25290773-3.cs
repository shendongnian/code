    using System.Collections.Generic;
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
            private List<ItemViewModel> _items;
            public List<ItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }
            private ItemViewModel _selectedItem;
            public ItemViewModel SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged("SelectedItem"); } }
            public ComboBoxResetViewModel()
            {
                this.Items = new List<ItemViewModel>()
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
