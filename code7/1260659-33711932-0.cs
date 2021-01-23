    public class UsersOrders
    {
        [Key]
        public int OrderID { get; set; }
        [Key]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
