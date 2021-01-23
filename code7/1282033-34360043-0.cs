    public class Sale
    {
        public int PaidAmount { get; set; }
        public int Some { get; set; }
        public int More { get; set; }
        public int Properties { get; set; }
    }
    public class SaleEditor
    {
        private Sale _sale;
        public int PaidAmount { get; set; }
        public SaleEditor(Sale sale)
        {
            _sale = sale;
            PaidAmount = sale.PaidAmount;
        }
        public void Save()
        {
            // update your data here
            _sale.PaidAmount = PaidAmount;
        }
    }
