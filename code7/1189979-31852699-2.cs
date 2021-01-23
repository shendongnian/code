    class RibbonViewModel
    {
        ObservableCollection<RibbonItem> _MenuItems;
    
        ObservableCollection<RibbonItem> _QuickMenuItems;
    
        public ObservableCollection<RibbonItem> MenuItems
        {
            get { return _MenuItems; }
        }
    
        public ObservableCollection<RibbonItem> QuickMenuItems
        {
            get { return _QuickMenuItems; }
        }
    
        public RibbonViewModel()
        {
            _QuickMenuItems = new ObservableCollection<RibbonItem>();
            _MenuItems = new ObservableCollection<RibbonItem>();
        }
    
        public class RibbonItem
        {
            public RibbonItem(string label, string imageUri, ICommand command)
            {
                Label = label;
                ImageUri = imageUri;
                Command = command;
            }
    
            public string Label { get; private set; }
    
            public string ImageUri { get; private set; }
    
            public ICommand Command { get; private set; }
    
            public string RibbonId { get; private set; }
        }
    }
