    public class ProductFilter
    {
        [RegularExpression(@"^(|[a-zA-Z0-9]{11})$")]
        public String Number { get; set; }
        .....
    }
