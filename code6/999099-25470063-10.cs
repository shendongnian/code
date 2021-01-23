    class ViewModel 
    {
        public ViewModel()
        {
            TreeItems = new ObservableCollection<Item>();
            string[] data = new string[]{
                    "Subchapter 1","Subchapter 2",
                };
            Item item = new Item()
            {
                Header = "Sub Getting Started",
                TreeItems = new List<string>(data)
            };
            TreeItems.Add(new Item()
            {
                Header = "Getting Started 1",
                SubItems = new List<Item>(new Item[] { item }),
                TreeItems = new List<string>(data)
            });
            TreeItems.Add(new Item()
            {
                Header = "Getting Started 2",
                SubItems = new List<Item>(new Item[] { item }),
                TreeItems = new List<string>(data)
            });
            TreeItems.Add(new Item()
            {
                Header = "Getting Started 3",
                SubItems = new List<Item>(new Item[] { item }),
                TreeItems = new List<string>(data)
            });
        }
        public ObservableCollection<Item> TreeItems { get; private set; }
    }
