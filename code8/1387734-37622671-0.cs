    public class Purchase
    {
        public Purchase()
        {
            PurchaseItems = new ObservableListSource<PurchaseItem>();
        }
    
        public int ID { get; set; }
        public string PurchaseBillNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal TotalBillAmount { get; set; }
        public ObservableListSource<PurchaseItem> PurchaseItems { get; set; }
    }
 
