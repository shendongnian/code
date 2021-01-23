    public class Item
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
