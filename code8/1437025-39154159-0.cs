    public class ShoppingCartModel
    {
        [Key]
        public int ID {get;set;}
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
