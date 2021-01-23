    public class List
    {
        public IList<Item> Entries => new List<Item>
            {
                new Item { EntryColor = Brushes.Cyan, SequenceNumber = 1 },
                new Item { EntryColor = Brushes.Red, SequenceNumber = 2 },
                new Item { EntryColor = Brushes.Orange, SequenceNumber = 3 },
            };
        public Item SelectedItem { get; set; }
    }
