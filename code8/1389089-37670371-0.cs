    public class MyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public class Item {
            public string Name { get; set; }
            public string Color { get; set; }
        }
        public List<Item> Items {get; set;}
    }
