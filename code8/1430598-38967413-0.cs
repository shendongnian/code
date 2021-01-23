    public class ViewModel
    {
        public List<Item> Items {get;} = new List<Item>
        {
            new Item { Value = "UI1" },
            new Item { Value = "UI2" },
        };
		
        public class Item
        {
            public string Value {get;set;}
        }
    }
