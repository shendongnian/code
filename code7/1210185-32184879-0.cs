    public class GoodsIssueProcess
    {
        [Key, Column(Order = 1), MaxLength(128)]
        public string DeliveryNote { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
    }
