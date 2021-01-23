    public class ModelExample : INotfyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int selectedCBItem;
        public int SelectedCBItem
        {
            get { return selectedCBItem; }
            set
            {
                selectedCBItem = value;
                NotifyPropertyChanged(nameof(SelectedCBItem));
            }
        }
        private List<ComboBoxItem> cbItems;
        public List<ComboBoxItem> CBItems
        {
            get { return cbItems; }
            set
            {
                cbItems= value;
                NotifyPropertyChanged(nameof(CBItems));
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ExampleWindow
    {
        ...
        private ModelExample Model;
        private void Initialize()
        {
            ...
            this.DataContext = Model = new ModelExample();
            List<ComboBoxItem> items = // initialize your items somehow
            items.Add(new ComboBoxItem() { Content = "dummy item 1" });
            items.Add(new ComboBoxItem() { Content = "dummy item 2" });
            Model.CBItems = items;
            Model.SelectedCBItem = 1;
        }
    }
