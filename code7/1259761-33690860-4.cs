    public class MyViewModel
    {
        public MyViewModel()
        {
            MyList = new List<Item>()
            {
                new Item {Name="1",Number=1 },
                new Item {Name="2",Number=2 },
                new Item {Name="3",Number=3 }
            };
        }
        public List<Item> MyList { get; set; }
    }
    public class Item
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}, Number {1}", this.Name, this.Number);
        }
    }
