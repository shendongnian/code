    public class ViewModel
    {
        public ViewModel()
        {
            // select something
            SelectedValue = Items[5];
        }
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>
        {
            "Item 1",
            "Item 2",
            "Item 3 long enough to use horizontal scroll",
            "Item 4",
            "Item 5",
            "Item 6", 
            "Item 7",
            "Item 8",
            "Item 9"
        };
        // To save which item is selected
        public Item SelectedValue { get; set; }
        public class Item
        {
            public string Text { get; set; }
            public bool IsSelected { get; set; }
            public static implicit operator Item(string text) => new Item {Text = text};
        }
    }
