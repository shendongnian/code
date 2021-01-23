    public class Item
    {
        public Item()
        {
            this.Stocks = new Collection<Stock>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
