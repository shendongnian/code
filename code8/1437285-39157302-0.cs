    public class Element
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
