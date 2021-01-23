    public class Item
    {
        public string Text
        {
            get
            {
                return "Itemaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            }
        }
        public List<Item> Items
        {
            get
            {
                return new List<Item>()
                {
                    new Item(),
                    new Item(),
                    new Item(),
                };
            }
        }
    }
