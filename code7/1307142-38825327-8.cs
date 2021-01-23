     public class ViewModel
    {
        public class Item
        {
            public string Text { get; set; }
            public bool IsSelected { get; set; }
            public static implicit operator Item(string text) => new Item() { Text = text };
        }
        public ViewModel()
        {
            for (int i = 0; i < 50; i++)
            {
                var text = "";
                for (int j = 0; j < i; j++)
                {
                    text += "Item " + i;
                }
                Items.Add(new Item() { Text = text });
            }
        }
        public double HorizontalOffset { get; set; }
        public double VerticalOffset { get; set; }
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
    }
