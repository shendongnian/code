    public class Product
    {
        public int Id { get; set; }
        //Rest of your fields
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
