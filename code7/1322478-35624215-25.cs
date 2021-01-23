    public class ProductStatistics
    {
        public string Product_ID { get; set; }
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
