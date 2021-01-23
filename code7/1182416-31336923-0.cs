    [Validator(typeof(ProductDetailsRequestDTO))]
    public class ProductDetailsRequestDTO
    {
        public int ArticleGroup { get; set; }
        public DateTime ProducedAt { get; set; }
    }
