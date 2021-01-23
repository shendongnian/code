    // INotifyPropertyChanged if you need, as well as full-properties with notification
    public class Item
    {
        public string Text {get; set;}
    }
    public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
    void OnCommandAdd() => Items.Add(new Item());
