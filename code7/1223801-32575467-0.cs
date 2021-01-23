    public partial class OrderMaster
    {
        public OrderMaster()
        {
            orderDetails = new List<OrderDetails>();
        }
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(200)]
        public string CustomerAddress { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
