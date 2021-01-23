<!-- -->
    public class ViewModel : BindableBase
    {
        private Item _selectedItem;
        public Item[] Items { get; }
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != null) _selectedItem.IsSelected = false;
                if (value != null) value.IsSelected = true;
                SetProperty(ref _selectedItem, value);
            }
        }
    }
    public class Item : BindableBase
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
