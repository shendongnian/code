    public class MyDataContext
    {
        public ICollectionView MyItems { get; set; }
        public MyDataContext()
        {
            List<Item> items = new List<Item>
            {
                new Item { CurrencySymbol = "$", SomeNumber = 123.4 },
                new Item { CurrencySymbol = "₹", SomeNumber = 0 },
                new Item { CurrencySymbol = "₹", SomeNumber = -14345623.7 }
            };
            MyItems = CollectionViewSource.GetDefaultView(items);
        }
    }
    public class Item
    {
        public double SomeNumber { get; set; }
        public string CurrencySymbol { get; set; }
    }
