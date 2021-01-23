    public class ProductStatistics
    {
       [Display(Name = "Product ID")]
        public string Product_ID { get; set; }
       [Display(Name = "Product Name")]
        public string ProductName { get; set; }
    }
    public class ProductStatisticsList
    {
        public List<ProductStatistics> Products
        {
            get;
            set;
        }
        public int SelectedMonth
        {
            get;
            set;
        }
        public int SelectedYear
        {
            get;
            set;
        }
    }
