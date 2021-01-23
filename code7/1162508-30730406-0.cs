    void Main()
        {
            var lst = new List<Item>() { new Item() { Prop1 = "A", Prop2 = "B", Prop3 = "C" }, new Item() { Prop1 = "Z", Prop2 = "R", Prop3 = "C" }, new Item() { Prop1 = "K", Prop2 = "B", Prop3 = "C" }};
           var result= lst.OrderBy(el => el.Prop1);
        }
    
        // Define other methods and classes here
        public class Item
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
            public string Prop3 { get; set; }
        }
