    public class PurchaseOrderViewModel
    {
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
    public class PurchaseOrderItem
    {
        public int Quantity { get; set; }
    }
