    public class BillLine
    {
        public int DiscountValue { get; set; }
        public Article Article { get; set; }
        public float FinalBillLinePrice
        {
            get
            {
                return Article.TotalArticlePrice - DiscountValue;
            }
          
        }
    }
