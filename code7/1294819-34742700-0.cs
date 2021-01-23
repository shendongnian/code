    [NotMapped]
    public class v_OrdersByUser
    {
        [Key]
        public string UserName { get; set; }
        public int OrdersCount { get; set; }
    }
