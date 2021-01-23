    public class MenuViewModel : Screen
    {
        public BindableCollection<SectionViewModel> Items { get; }    
        public MenuViewModel(IEnumerable<SectionViewModel> sections)
        {
            Items = new BindableCollection<SectionViewModel>(sections);
            PropertyChanged += OnPropertyChanged;
        }
        private SectionViewModel _selectedItem;
        public SectionViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                    return;
                _selectedItem = value;
                NotifyOfPropertyChange(nameof(SelectedItem));
            }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(SelectedItem))
            {
                foreach (var item in Items)
                {
                    item.Selected = item == SelectedItem;
                }
            }
        }
    }
