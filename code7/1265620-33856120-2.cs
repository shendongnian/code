    public class Person
    {
        public string[] Aliases { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Bars Bars { get; set; }
    }
    public class Bars
    {
        public Item[] items { get; set; }
    }
    public class Item
    {
        public string Sub_Property1 { get; set; }
        public string Sub_Property2 { get; set; }
    }
