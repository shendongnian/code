    public class MyViewModel : INotifyPropertyChanged
    {
        public Dictionary<string, string> AvailableItems { get; set; }
        private string _selectedItem;
        public string SelectedItem 
        {
            get { return _selectedItem; }
            set 
            {
                _selectedItem = value;
                RaisePropertyChanged("SomeValue");
                RaisePropertyChanged("Value"); // Notify Value it has changed too
            }
        }
        public string Value
        {
            get { return AvailableItems[SelectedItem]; }
            set { AvailableItems[SelectedItem] = value; }
        }
        public MyViewModel()
        {
            AvailableItems = new Dictionary<string, string>();
            AvailableItems.Add("Fixed", string.Empty);
            AvailableItems.Add("Percent", string.Empty);
            AvailableItems.Add("Variable", string.Empty);
            SelectedItem = AvailableItems[0];
        }
    }
