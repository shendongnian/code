    public class Article
    {
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float TotalArticlePrice
        {
            get
            {
                return Price * Quantity;
            }
           
        }
    }
